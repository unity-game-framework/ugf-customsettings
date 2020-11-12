using NUnit.Framework;

namespace UGF.CustomSettings.Editor.Tests
{
    public class TestSettingsEditor
    {
        [Test]
        public void Package()
        {
            Assert.AreEqual("Editor Package", TestSettingsEditorPackage.Settings.GetData().Name);
        }

        [Test]
        public void PackageExternal()
        {
            Assert.AreEqual("Editor Package External", TestSettingsEditorPackageExternal.Settings.GetData().Name);
        }
    }
}
