using NUnit.Framework;
using UGF.CustomSettings.Runtime.Tests;
using UGF.EditorTools.Editor.Yaml;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public class TestSettingsPackageChange
    {
        private string m_previousName;
        private const string PATH = "Assets/Settings/Resources/UGF.Test.Package/TestPackageSettings.asset";

        [OneTimeSetUp]
        public void SetupAll()
        {
            var data = EditorYamlUtility.FromYamlAtPath<TestSettingsData>(PATH);

            m_previousName = data.Name;
        }

        [OneTimeTearDown]
        public void TeardownAll()
        {
            var data = EditorYamlUtility.FromYamlAtPath<TestSettingsData>(PATH);

            data.Name = m_previousName;

            EditorYamlUtility.ToYamlAtPath(data, PATH);
            AssetDatabase.ImportAsset(PATH);
            AssetDatabase.SaveAssets();
        }

        [Test]
        public void Change()
        {
            string name = "Test Name Change";
            TestSettingsPackage.Settings.GetData().Name = name;
            TestSettingsPackage.Settings.SaveSettings();

            var data = EditorYamlUtility.FromYamlAtPath<TestSettingsData>(PATH);

            Assert.AreEqual(name, data.Name);
        }
    }
}
