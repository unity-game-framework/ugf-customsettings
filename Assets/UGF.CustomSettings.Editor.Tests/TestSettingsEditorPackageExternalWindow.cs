using UGF.CustomSettings.Runtime;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public class TestSettingsEditorPackageExternalWindow : CustomSettingsWindow<TestSettingsEditorData>
    {
        [MenuItem("Tests/TestSettingsEditorPackageExternalWindow")]
        private static void Menu()
        {
            GetWindow<TestSettingsEditorPackageExternalWindow>(false, "Settings");
        }

        protected override CustomSettings<TestSettingsEditorData> OnGetSettings()
        {
            return TestSettingsEditorPackageExternal.Settings;
        }
    }
}
