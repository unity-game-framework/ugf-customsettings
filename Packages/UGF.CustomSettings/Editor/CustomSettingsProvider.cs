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
        public CustomSettings<TData> Settings { get; }

        private AssetSettingsProvider m_provider;

        /// <summary>
        /// Creates provider with the specified settings path and custom settings.
        /// </summary>
        /// <param name="path">The path of the settings in settings window.</param>
        /// <param name="settings">The settings of the specific data to display.</param>
        /// <param name="scopes">The scope of the settings.</param>
        /// <param name="keywords">The search keywords.</param>
        public CustomSettingsProvider(string path, CustomSettings<TData> settings, SettingsScope scopes, IEnumerable<string> keywords = null) : base(path, scopes, keywords)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            CustomSettingsDataContextMenu.ClearMenu += OnContextClearMenu;
            CustomSettingsDataContextMenu.ClearValidate += OnContextClearValidate;
            EditorApplication.playModeStateChanged += OnEditorApplicationPlayModeStateChanged;

            ClearEditor();
            CreateEditor();

            base.OnActivate(searchContext, rootElement);
        }

        public override void OnDeactivate()
        {
            CustomSettingsDataContextMenu.ClearMenu -= OnContextClearMenu;
            CustomSettingsDataContextMenu.ClearValidate -= OnContextClearValidate;
            EditorApplication.playModeStateChanged -= OnEditorApplicationPlayModeStateChanged;

            ClearEditor();

            base.OnDeactivate();

            if (Settings.Exists())
            {
                Settings.SaveSettings();
            }
        }

        public override void OnGUI(string searchContext)
        {
            if (m_provider != null)
            {
                EditorGUI.BeginChangeCheck();

                m_provider.OnGUI(searchContext);

                if (EditorGUI.EndChangeCheck())
                {
                    Settings.SaveSettings(false);
                }
            }
            else
            {
                EditorGUILayout.Space();
                EditorGUILayout.HelpBox($"Settings data not created: '{Settings.DataType.Name}'.", MessageType.Info);
                EditorGUILayout.Space();

                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.FlexibleSpace();

                    if (GUILayout.Button("Create Settings", GUILayout.Width(200F)))
                    {
                        Settings.LoadSettings();
                        Settings.SaveSettings();

                        CreateEditor();
                    }

                    GUILayout.FlexibleSpace();
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

        private void OnContextClearMenu(CustomSettingsData data)
        {
            if (m_provider != null && m_provider.settingsEditor.target == data)
            {
                string message = $"Data will be deleted for settings at specified path: '{settingsPath}'.\nYou cannot undo this action.";

                if (EditorUtility.DisplayDialog("Delete selected settings data?", message, "Delete", "Cancel"))
                {
                    ClearEditor();
                    Settings.ClearSettings();
                }
            }
        }

        private bool OnContextClearValidate(CustomSettingsData data)
        {
            if (m_provider != null && m_provider.settingsEditor.target == data)
            {
                return Settings.Exists();
            }

            return false;
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
            if (Settings.ForceCreation || Settings.Exists())
            {
                Settings.LoadSettings();

                TData data = Settings.GetData();

                m_provider = AssetSettingsProvider.CreateProviderFromObject(string.Empty, data);
                m_provider.OnActivate(string.Empty, null);

                keywords = GetSearchKeywordsFromSerializedObject(new SerializedObject(data));
            }
        }
    }
}
