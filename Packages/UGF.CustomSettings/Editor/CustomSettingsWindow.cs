using UGF.CustomSettings.Runtime;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;
using UnityEngine;

namespace UGF.CustomSettings.Editor
{
    public abstract class CustomSettingsWindow<TData> : EditorWindow where TData : ScriptableObject
    {
        public CustomSettingsDrawer<TData> Drawer { get; private set; }

        private Vector2 m_scroll = Vector2.zero;

        protected virtual void OnEnable()
        {
            CustomSettings<TData> settings = OnGetSettings();

            Drawer = new CustomSettingsDrawer<TData>(settings);
            Drawer.Enable();
        }

        protected virtual void OnDisable()
        {
            Drawer.Disable();
        }

        private void OnGUI()
        {
            if (titleContent.image == null)
            {
                titleContent.image = EditorGUIUtility.IconContent("Settings").image;
            }

            OnDrawLayout();
        }

        protected abstract CustomSettings<TData> OnGetSettings();

        protected virtual void OnDrawLayout()
        {
            m_scroll = EditorGUILayout.BeginScrollView(m_scroll);

            OnDrawSettingsLayout();

            EditorGUILayout.EndScrollView();
        }

        protected virtual void OnDrawSettingsLayout()
        {
            using (new InspectorGUIScope(true))
            {
                EditorGUILayout.Space(EditorGUIUtility.standardVerticalSpacing);

                Drawer.DrawGUILayout();
            }
        }
    }
}
