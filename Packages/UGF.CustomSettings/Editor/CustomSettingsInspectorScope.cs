using System;
using UnityEditor;

namespace UGF.CustomSettings.Editor
{
    /// <summary>
    /// Represents the GUI scope used to draw editor in project settings.
    /// </summary>
    /// <remarks>
    /// The main purposes to setup settings to be the same as during drawing editor in 'Inspector' window.
    /// </remarks>
    public struct CustomSettingsInspectorScope : IDisposable
    {
        private readonly bool m_hierarchyMode;
        private readonly bool m_wideMode;

        /// <summary>
        /// Creates scope with the specified enabled argument.
        /// </summary>
        /// <param name="enable">The value determines whether to enable settings in scope.</param>
        public CustomSettingsInspectorScope(bool enable)
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
