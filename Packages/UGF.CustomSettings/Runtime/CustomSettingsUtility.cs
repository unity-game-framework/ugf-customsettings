using System.IO;

namespace UGF.CustomSettings.Runtime
{
    /// <summary>
    /// Provides utilities to work with custom setting.
    /// </summary>
    public static class CustomSettingsUtility
    {
        /// <summary>
        /// Represents the default path of the settings data asset used for runtime package settings.
        /// </summary>
        public const string DEFAULT_PACKAGE_FOLDER = "Assets/Settings/Resources";

        public static void CheckAndCreateDirectory(string path)
        {
            string directory = Path.GetDirectoryName(path);

            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
