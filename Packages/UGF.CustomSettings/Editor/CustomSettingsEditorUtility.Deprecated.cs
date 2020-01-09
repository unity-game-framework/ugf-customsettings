using System;

namespace UGF.CustomSettings.Editor
{
    public static partial class CustomSettingsEditorUtility
    {
        /// <summary>
        /// Represents the default path of the settings data asset used for editor package settings.
        /// </summary>
        [Obsolete("DefaultPackageFolder has been deprecated. Use DEFAULT_PACKAGE_FOLDER instead.")]
        public const string DefaultPackageFolder = "Assets/Settings/Editor";

        /// <summary>
        /// Represents the default path of the settings data asset used for editor package settings and stored under the 'ProjectSettings' folder.
        /// </summary>
        [Obsolete("DefaultPackageExternalFolder has been deprecated. Use DEFAULT_PACKAGE_EXTERNAL_FOLDER instead.")]
        public const string DefaultPackageExternalFolder = "ProjectSettings/Packages";
    }
}
