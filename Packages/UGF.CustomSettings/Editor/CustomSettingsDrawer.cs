using System;
using UGF.CustomSettings.Runtime;
using UGF.EditorTools.Editor.IMGUI;
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
        }

        public void Enable()
        {
            Settings.Loaded += OnLoaded;
        }

        public void Disable()
        {
            Settings.Loaded -= OnLoaded;
        }

        public void DrawGUILayout()
        {
        }

        protected virtual void OnDrawGUILayout()
        {
            Drawer.DrawGUILayout();
        }

        private void OnLoaded()
        {
        }
    }
}
