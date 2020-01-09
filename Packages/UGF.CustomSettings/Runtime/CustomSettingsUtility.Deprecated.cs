using System;

namespace UGF.CustomSettings.Runtime
{
    public static partial class CustomSettingsUtility
    {
        /// <summary>
        /// Represents the default path of the settings data asset used for runtime package settings.
        /// </summary>
        [Obsolete("DefaultPackageFolder has been deprecated. Use DEFAULT_PACKAGE_FOLDER instead.")]
        public const string DefaultPackageFolder = "Assets/Settings/Resources";
    }
}
