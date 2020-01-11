using System;
using UnityEngine;

namespace UGF.CustomSettings.Editor
{
    /// <summary>
    /// Represents custom settings stored at specified asset path as settings data asset, but with additional options specific for package settings.
    /// </summary>
    /// <remarks>
    /// The settings can be saved at any path under the 'Assets' folder or in 'ProjectSettings' folder.
    ///
    /// The default path for assets under the 'Assets' folder is 'Assets/Settings/Editor', and 'ProjectSettings/Packages' for external folder.
    /// </remarks>
    public class CustomSettingsEditorPackage<TData> : CustomSettingsEditorAsset<TData> where TData : ScriptableObject
    {
        /// <summary>
        /// Creates settings with the specified package name and settings name.
        /// </summary>
        /// <param name="packageName">The name of the package.</param>
        /// <param name="settingsName">The name of the settings.</param>
        /// <param name="folderPath">The path of the folder to store settings data asset.</param>
        public CustomSettingsEditorPackage(string packageName, string settingsName = "Settings", string folderPath = CustomSettingsEditorUtility.DEFAULT_PACKAGE_EXTERNAL_FOLDER) : base($"{folderPath}/{packageName}/{settingsName}.asset")
        {
            if (string.IsNullOrEmpty(packageName)) throw new ArgumentException("The package name cannot be null or empty.", nameof(packageName));
            if (string.IsNullOrEmpty(settingsName)) throw new ArgumentException("The settings name cannot be null or empty.", nameof(settingsName));
            if (string.IsNullOrEmpty(folderPath)) throw new ArgumentException("The folder path cannot be null or empty.", nameof(folderPath));
        }
    }
}
