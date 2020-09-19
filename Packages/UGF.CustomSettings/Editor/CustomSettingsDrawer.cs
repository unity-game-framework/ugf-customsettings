using System;
using UGF.CustomSettings.Runtime;
using UGF.EditorTools.Editor.IMGUI;
using UnityEditor;
using UnityEngine;

namespace UGF.CustomSettings.Editor
{
    public class CustomSettingsDrawer<TData> where TData : ScriptableObject
    {
        public CustomSettings<TData> Settings { get; }

        public EditorDrawer Drawer { get; } = new EditorDrawer
        {
            DisplayTitlebar = false
        };

        public CustomSettingsDrawer(CustomSettings<TData> settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            Drawer.Set(Settings.Data);
        }

        public void Enable()
        {
            Settings.Loaded += OnLoaded;
        }

        public void Disable()
        {
            Settings.Loaded -= OnLoaded;
            Settings.SaveSettings();
        }

        public void DrawGUILayout()
        {
            EditorGUI.BeginChangeCheck();

            OnDrawGUILayout();

            if (EditorGUI.EndChangeCheck())
            {
                Settings.SaveSettings();
            }
        }

        protected virtual void OnDrawGUILayout()
        {
            if (Drawer.HasEditor && Drawer.Editor.target != null)
            {
                Drawer.DrawGUILayout();
            }
        }

        private void OnLoaded(TData data)
        {
            Drawer.Set(data);
        }
    }
}
