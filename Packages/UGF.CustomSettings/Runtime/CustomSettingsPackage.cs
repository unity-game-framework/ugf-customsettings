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
    /// Calling of the 'SaveSettings' and 'ClearSettings' method has effect only in Editor.
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
        /// Gets the full path of the asset at editor project.
        /// </summary>
        public string AssetPath { get; }

        /// <summary>
        /// Creates settings with the specified package name, settings name and folder path to store settings data asset in editor.
        /// </summary>
        /// <remarks>
        /// The folder path must be under the 'Assets' folder and must be a part of the 'Resources'.
        /// </remarks>
        /// <param name="packageName">The name of the package.</param>
        /// <param name="settingsName">The name of the settings.</param>
        /// <param name="folderPath">The editor folder to store settings data asset.</param>
        public CustomSettingsPackage(string packageName, string settingsName = "Settings", string folderPath = CustomSettingsUtility.DEFAULT_PACKAGE_FOLDER) : base($"{packageName}/{settingsName}")
        {
            if (string.IsNullOrEmpty(packageName)) throw new ArgumentException("The package name cannot be null or empty.", nameof(packageName));
            if (string.IsNullOrEmpty(settingsName)) throw new ArgumentException("The settings name cannot be null or empty.", nameof(settingsName));
            if (string.IsNullOrEmpty(folderPath)) throw new ArgumentException("The folder path cannot be null or empty.", nameof(folderPath));
            if (!folderPath.StartsWith("Assets")) throw new ArgumentException("The folder path must be in 'Assets' folder.", nameof(folderPath));
            if (!folderPath.Contains("Resources")) throw new ArgumentException("The folder path must be a part of 'Resources'.", nameof(folderPath));

            FolderPath = folderPath;
            AssetPath = $"{FolderPath}/{ResourcesPath}.asset";
        }

        public override bool Exists()
        {
#if UNITY_EDITOR
            return File.Exists(AssetPath);
#else
            return base.Exists();
#endif
        }

        protected override void OnSaveSettings(TData data)
        {
#if UNITY_EDITOR
            if (data == null) throw new ArgumentNullException(nameof(data));

            CustomSettingsUtility.CheckAndCreateDirectory(AssetPath);

            UnityEditor.AssetDatabase.CreateAsset(data, AssetPath);
            UnityEditor.AssetDatabase.ImportAsset(AssetPath);
#endif
        }

        protected override TData OnLoadSettings()
        {
#if UNITY_EDITOR
            if (!Exists())
            {
                var data = ScriptableObject.CreateInstance<TData>();

                OnSaveSettings(data);
            }
#endif

            return base.OnLoadSettings();
        }

        protected override void OnClearSettings()
        {
            base.OnClearSettings();

#if UNITY_EDITOR
            if (Exists())
            {
                UnityEditor.AssetDatabase.MoveAssetToTrash(AssetPath);
            }
#endif
        }
    }
}
