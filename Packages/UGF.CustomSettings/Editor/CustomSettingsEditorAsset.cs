using System;
using System.IO;
using UGF.CustomSettings.Runtime;
using UGF.EditorTools.Editor.Yaml;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.CustomSettings.Editor
{
    /// <summary>
    /// Represents custom settings stored at specified asset path as settings data asset.
    /// </summary>
    /// <remarks>
    /// This settings supports saving and loading settings data asset whether asset path points to file under the 'Assets' folder or not.
    ///
    /// In editor settings data asset automatically created at specified asset path, if asset not yet created.
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
                EditorYamlUtility.ToYamlAtPath(data, AssetPath);
            }
            else
            {
                if (Exists())
                {
                    EditorUtility.SetDirty(data);
                }
                else
                {
                    CustomSettingsUtility.CheckAndCreateDirectory(AssetPath);
                    AssetDatabase.CreateAsset(data, AssetPath);
                    AssetDatabase.ImportAsset(AssetPath);
                }

                AssetDatabase.SaveAssets();
            }
        }

        protected override TData OnLoadSettings()
        {
            if (!Exists())
            {
                var data = ScriptableObject.CreateInstance<TData>();

                OnSaveSettings(data);
            }

            return HasExternalPath ? EditorYamlUtility.FromYamlAtPath<TData>(AssetPath) : AssetDatabase.LoadAssetAtPath<TData>(AssetPath);
        }

        protected override void OnClearSettings()
        {
            base.OnClearSettings();

            if (Exists())
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

        protected override void OnDestroySettings(TData data)
        {
            base.OnDestroySettings(data);

            if (HasExternalPath || !Exists())
            {
                Object.DestroyImmediate(data);
            }
        }
    }
}
