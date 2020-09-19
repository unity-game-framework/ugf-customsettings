using UGF.CustomSettings.Runtime;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public class TestSettingsEditorPackageWindow : CustomSettingsWindow<TestSettingsEditorData>
    {
        [MenuItem("Tests/TestSettingsEditorPackageWindow")]
        private static void Menu()
        {
            GetWindow<TestSettingsEditorPackageWindow>(false, "Test Settings");
        }

        protected override CustomSettings<TestSettingsEditorData> OnGetSettings()
        {
            return TestSettingsEditorPackage.Settings;
        }
    }
}
