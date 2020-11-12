using NUnit.Framework;
using UGF.EditorTools.Editor.Yaml;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public class TestSettingsEditorPackageChange
    {
        private string m_previousName;
        private const string PATH = "Assets/Settings/Editor/UGF.Test.Editor.Package/TestEditorPackageSettings.asset";

        [OneTimeSetUp]
        public void SetupAll()
        {
            var data = EditorYamlUtility.FromYamlAtPath<TestSettingsEditorData>(PATH);

            m_previousName = data.Name;
        }

        [OneTimeTearDown]
        public void TeardownAll()
        {
            var data = EditorYamlUtility.FromYamlAtPath<TestSettingsEditorData>(PATH);

            data.Name = m_previousName;

            EditorYamlUtility.ToYamlAtPath(data, PATH);
            AssetDatabase.ImportAsset(PATH);
            AssetDatabase.SaveAssets();
        }

        [Test]
        public void Change()
        {
            string name = "Test Name Change";
            TestSettingsEditorPackage.Settings.GetData().Name = name;
            TestSettingsEditorPackage.Settings.SaveSettings();

            var data = EditorYamlUtility.FromYamlAtPath<TestSettingsEditorData>(PATH);

            Assert.AreEqual(name, data.Name);
        }
    }
}
