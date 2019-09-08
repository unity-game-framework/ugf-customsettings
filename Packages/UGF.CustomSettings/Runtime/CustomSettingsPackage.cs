using System;
using System.IO;
using UnityEngine;

namespace UGF.CustomSettings.Runtime
{
    /// <summary>
    /// Represents custom settings stored at resources folder as settings data asset, but with additional options specific for package settings.
    /// </summary>
    /// <remarks>
    /// In build just loads settings data asset from resources.
    ///
    /// In editor settings data asset automatically created at specified editor folder, if asset not yet created.
    ///
    /// The default folder path is 'Assets/Settings/Resources'.
    /// </remarks>
    public class CustomSettingsPackage<TData> : CustomSettingsResources<TData> where TData : ScriptableObject
    {
        /// <summary>
        /// Gets the path of the folder to store settings data asset.
        /// </summary>
        public string FolderPath { get; }

        /// <summary>
        /// Creates settings with the specified package name, settings name and folder path to store settings data asset in editor.
        /// </summary>
        /// <remarks>
        /// The folder path must be under the 'Assets' folder and must be a part of the 'Resources'.
        /// </remarks>
        /// <param name="packageName">The name of the package.</param>
        /// <param name="settingsName">The name of the settings.</param>
        /// <param name="folderPath">The editor folder to store settings data asset.</param>
        public CustomSettingsPackage(string packageName, string settingsName = "Settings", string folderPath = CustomSettingsUtility.DefaultPackageFolder) : base($"{packageName}/{settingsName}")
        {
            if (string.IsNullOrEmpty(packageName)) throw new ArgumentException("The package name cannot be null or empty.", nameof(packageName));
            if (string.IsNullOrEmpty(settingsName)) throw new ArgumentException("The package name cannot be null or empty.", nameof(settingsName));
            if (string.IsNullOrEmpty(folderPath)) throw new ArgumentException("The folder path cannot be null or empty.", nameof(folderPath));
            if (!folderPath.StartsWith("Assets")) throw new ArgumentException("The folder path must be in 'Assets' folder.", nameof(folderPath));
            if (!folderPath.Contains("Resources")) throw new ArgumentException("The folder path must be a part of 'Resources'.", nameof(folderPath));

            FolderPath = folderPath;
        }

        protected override TData Load()
        {
#if UNITY_EDITOR
            string assetPath = $"{FolderPath}/{ResourcesPath}.asset";

            if (!File.Exists(assetPath))
            {
                string directoryName = Path.GetDirectoryName(assetPath);

                if (!string.IsNullOrEmpty(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                var data = ScriptableObject.CreateInstance<TData>();

                UnityEditor.AssetDatabase.CreateAsset(data, assetPath);
                UnityEditor.AssetDatabase.ImportAsset(assetPath);
            }
#endif

            return base.Load();
        }
    }
}
