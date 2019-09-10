using System;
using UnityEditor;

namespace UGF.CustomSettings.Editor
{
    internal class CustomSettingsGUIScope : IDisposable
    {
        private readonly bool m_hierarchyMode;
        private readonly bool m_wideMode;

        public CustomSettingsGUIScope()
        {
            m_hierarchyMode = EditorGUIUtility.hierarchyMode;
            m_wideMode = EditorGUIUtility.wideMode;

            EditorGUIUtility.hierarchyMode = true;
            EditorGUIUtility.wideMode = true;
        }

        public void Dispose()
        {
            EditorGUIUtility.hierarchyMode = m_hierarchyMode;
            EditorGUIUtility.wideMode = m_wideMode;
        }
    }
}
