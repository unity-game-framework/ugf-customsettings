using System;
using System.IO;
using UnityEngine;

namespace UGF.CustomSettings.Runtime
{
    public class CustomSettingsPackage<TData> : CustomSettingsResources<TData> where TData : ScriptableObject
    {
        public string FolderPath { get; }

        public CustomSettingsPackage(string packageName, string settingsName = "settings", string folderPath = "Assets/Settings/Resources") : base($"{packageName}.{settingsName}")
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
