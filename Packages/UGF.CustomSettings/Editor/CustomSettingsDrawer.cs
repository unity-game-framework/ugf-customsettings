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
        public EditorDrawer Drawer { get; } = new EditorDrawer();

        public CustomSettingsDrawer(CustomSettings<TData> settings)
        {
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            Drawer.Set(Settings.GetData());
        }

        public void Enable()
        {
            Settings.Loaded += OnLoaded;
            Drawer.Enable();
        }

        public void Disable()
        {
            Settings.Loaded -= OnLoaded;
            Settings.SaveSettings();
            Drawer.Disable();
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
