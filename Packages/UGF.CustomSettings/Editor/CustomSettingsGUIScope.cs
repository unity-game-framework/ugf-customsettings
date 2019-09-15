using System;
using UnityEditor;

namespace UGF.CustomSettings.Editor
{
    public class CustomSettingsGUIScope : IDisposable
    {
        private readonly bool m_hierarchyMode;
        private readonly bool m_wideMode;

        public CustomSettingsGUIScope(bool enable = true)
        {
            m_hierarchyMode = EditorGUIUtility.hierarchyMode;
            m_wideMode = EditorGUIUtility.wideMode;

            EditorGUIUtility.hierarchyMode = enable;
            EditorGUIUtility.wideMode = enable;
        }

        public void Dispose()
        {
            EditorGUIUtility.hierarchyMode = m_hierarchyMode;
            EditorGUIUtility.wideMode = m_wideMode;
        }
    }
}
