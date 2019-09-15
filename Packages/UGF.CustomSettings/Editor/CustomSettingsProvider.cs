using System;
using System.Collections.Generic;
using UGF.CustomSettings.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UGF.CustomSettings.Editor
{
    /// <summary>
    /// Represents 'SettingsProvider' for the specified 'CustomSettings' to display in 'Project Settings' or 'User Settings'.
    /// </summary>
    public class CustomSettingsProvider<TData> : SettingsProvider where TData : ScriptableObject
    {
        private AssetSettingsProvider m_provider;
        private readonly CustomSettings<TData> m_settings;

        /// <summary>
        /// Creates provider with the specified settings path and custom settings.
        /// </summary>
        /// <param name="path">The path of the settings in settings window.</param>
        /// <param name="settings">The settings of the specific data to display.</param>
        /// <param name="scopes">The scope of the settings.</param>
        /// <param name="keywords">The search keywords.</param>
        public CustomSettingsProvider(string path, CustomSettings<TData> settings, SettingsScope scopes, IEnumerable<string> keywords = null) : base(path, scopes, keywords ?? GetSearchKeywordsFromSerializedObject(new SerializedObject(settings.Data)))
        {
            m_settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            EditorApplication.playModeStateChanged += OnEditorApplicationPlayModeStateChanged;

            ClearEditor();
            CreateEditor();

            base.OnActivate(searchContext, rootElement);
        }

        public override void OnDeactivate()
        {
            EditorApplication.playModeStateChanged -= OnEditorApplicationPlayModeStateChanged;

            ClearEditor();

            base.OnDeactivate();
        }

        public override void OnGUI(string searchContext)
        {
            if (m_provider != null)
            {
                using (new CustomSettingsGUIScope())
                using (var change = new EditorGUI.ChangeCheckScope())
                {
                    m_provider.OnGUI(searchContext);

                    if (change.changed)
                    {
                        m_settings.Save();
                    }
                }
            }

            base.OnGUI(searchContext);
        }

        public override void OnTitleBarGUI()
        {
            m_provider?.OnTitleBarGUI();

            base.OnTitleBarGUI();
        }

        public override void OnFooterBarGUI()
        {
            m_provider?.OnFooterBarGUI();

            base.OnFooterBarGUI();
        }

        private void OnEditorApplicationPlayModeStateChanged(PlayModeStateChange playModeStateChange)
        {
            ClearEditor();
            CreateEditor();
        }

        private void ClearEditor()
        {
            if (m_provider != null)
            {
                m_provider.OnDeactivate();
                m_provider = null;
            }
        }

        private void CreateEditor()
        {
            m_provider = AssetSettingsProvider.CreateProviderFromObject(string.Empty, m_settings.Data);
            m_provider.OnActivate(string.Empty, null);
        }
    }
}
