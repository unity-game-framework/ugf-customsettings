using NUnit.Framework;

namespace UGF.CustomSettings.Editor.Tests
{
    public class TestSettingsEditor
    {
        [Test]
        public void Package()
        {
            Assert.AreEqual("Editor Package", TestSettingsEditorPackage.Settings.Data.Name);
        }

        [Test]
        public void PackageExternal()
        {
            Assert.AreEqual("Editor Package External", TestSettingsEditorPackageExternal.Settings.Data.Name);
        }
    }
}
