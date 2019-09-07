using System;
using System.IO;
using UGF.CustomSettings.Runtime;
using UnityEditor;
using UnityEditorInternal;
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
    ///
    /// A calling of the 'Save' method has effect only for assets out of the 'Assets' folder.
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
        public bool HasExternalPath { get { return !AssetPath.StartsWith("Assets"); } }

        /// <summary>
        /// Creates settings with the specified asset path.
        /// </summary>
        /// <param name="assetPath">The path of the asset.</param>
        public CustomSettingsEditorAsset(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath)) throw new ArgumentException("The asset path cannot be null or empty.", nameof(assetPath));

            AssetPath = assetPath;
        }

        protected override void Save(TData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            if (HasExternalPath)
            {
                InternalEditorUtility.SaveToSerializedFileAndForget(new Object[] { data }, AssetPath, true);
            }
        }

        protected override TData Load()
        {
            return HasExternalPath ? LoadFromFile(AssetPath) : LoadFromAssetDatabase(AssetPath);
        }

        private static TData LoadFromAssetDatabase(string assetPath)
        {
            var data = AssetDatabase.LoadAssetAtPath<TData>(assetPath);

            if (data == null)
            {
                CreateDirectory(assetPath);

                data = ScriptableObject.CreateInstance<TData>();

                AssetDatabase.CreateAsset(data, assetPath);
                AssetDatabase.ImportAsset(assetPath);
            }

            return data;
        }

        private static TData LoadFromFile(string assetPath)
        {
            Object[] array = InternalEditorUtility.LoadSerializedFileAndForget(assetPath);
            TData data = array != null && array.Length > 0 ? (TData)array[0] : null;

            if (data == null)
            {
                CreateDirectory(assetPath);

                data = ScriptableObject.CreateInstance<TData>();

                InternalEditorUtility.SaveToSerializedFileAndForget(new Object[] { data }, assetPath, true);
            }

            return data;
        }

        private static void CreateDirectory(string assetPath)
        {
            string directoryName = Path.GetDirectoryName(assetPath);

            if (!string.IsNullOrEmpty(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }
    }
}
