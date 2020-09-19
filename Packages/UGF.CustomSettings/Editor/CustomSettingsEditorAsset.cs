using System;
using System.IO;
using UGF.CustomSettings.Runtime;
using UGF.EditorTools.Editor.Yaml;
using UnityEditor;
using UnityEngine;

namespace UGF.CustomSettings.Editor
{
    /// <summary>
    /// Represents custom settings stored at specified asset path as settings data asset.
    /// </summary>
    /// <remarks>
    /// This settings supports saving and loading settings data asset whether asset path points to file under the 'Assets' folder or not.
    ///
    /// In editor settings data asset automatically created at specified asset path, if asset not yet created.
    ///
    /// A calling of the 'SaveSettings' method has effect only for assets out of the 'Assets' folder.
    /// </remarks>
    public class CustomSettingsEditorAsset<TData> : CustomSettings<TData> where TData : ScriptableObject
    {
        /// <summary>
        /// Gets the path of the asset.
        /// </summary>
        public string AssetPath { get; }

        /// <summary>
        /// Gets the value determines whether asset path points to file out of the root 'Assets' folder.
        /// </summary>
        public bool HasExternalPath { get; }

        /// <summary>
        /// Creates settings with the specified asset path.
        /// </summary>
        /// <param name="assetPath">The path of the asset.</param>
        public CustomSettingsEditorAsset(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath)) throw new ArgumentException("The asset path cannot be null or empty.", nameof(assetPath));

            AssetPath = assetPath;
            HasExternalPath = !AssetPath.StartsWith("Assets");
        }

        public override bool Exists()
        {
            return File.Exists(AssetPath);
        }

        protected override void OnSaveSettings(TData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            if (HasExternalPath)
            {
                CustomSettingsUtility.CheckAndCreateDirectory(AssetPath);
                EditorYamlUtility.ToYamlAtPath(Data, AssetPath);
            }
        }

        protected override TData OnLoadSettings()
        {
            return HasExternalPath ? LoadFromFile(AssetPath) : LoadFromAssetDatabase(AssetPath);
        }

        protected override void OnClearSettings()
        {
            base.OnClearSettings();

            if (File.Exists(AssetPath))
            {
                if (HasExternalPath)
                {
                    File.Delete(AssetPath);
                }
                else
                {
                    AssetDatabase.MoveAssetToTrash(AssetPath);
                }
            }
        }

        private static TData LoadFromAssetDatabase(string assetPath)
        {
            var data = AssetDatabase.LoadAssetAtPath<TData>(assetPath);

            if (data == null)
            {
                CustomSettingsUtility.CheckAndCreateDirectory(assetPath);

                data = ScriptableObject.CreateInstance<TData>();

                AssetDatabase.CreateAsset(data, assetPath);
                AssetDatabase.ImportAsset(assetPath);
            }

            return data;
        }

        private static TData LoadFromFile(string assetPath)
        {
            var data = EditorYamlUtility.FromYamlAtPath<TData>(assetPath);

            if (data == null)
            {
                CustomSettingsUtility.CheckAndCreateDirectory(assetPath);

                data = ScriptableObject.CreateInstance<TData>();

                EditorYamlUtility.ToYamlAtPath(data, assetPath);
            }

            return data;
        }
    }
}
