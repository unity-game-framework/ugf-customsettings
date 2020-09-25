using UGF.CustomSettings.Runtime;
using UnityEditor;

namespace UGF.CustomSettings.Editor
{
    [CustomEditor(typeof(CustomSettingsData), true)]
    public class CustomSettingsDataEditor : UnityEditor.Editor
    {
        private readonly string[] m_excluding = { "m_Script" };

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();

            DrawPropertiesExcluding(serializedObject, m_excluding);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
