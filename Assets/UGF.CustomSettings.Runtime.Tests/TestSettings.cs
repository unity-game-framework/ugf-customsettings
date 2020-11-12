using NUnit.Framework;

namespace UGF.CustomSettings.Runtime.Tests
{
    public class TestSettings
    {
        [Test]
        public void File()
        {
            Assert.AreEqual("File", TestSettingsFile.Settings.GetData().Name);
        }

        [Test]
        public void Package()
        {
            Assert.AreEqual("Package", TestSettingsPackage.Settings.GetData().Name);
        }
    }
}
