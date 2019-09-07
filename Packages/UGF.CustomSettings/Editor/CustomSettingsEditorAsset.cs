using System;
using System.IO;
using UGF.CustomSettings.Runtime;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.CustomSettings.Editor
{
    public class CustomSettingsEditorAsset<TData> : CustomSettings<TData> where TData : ScriptableObject
    {
        public string AssetPath { get; }
        public bool HasExternalPath { get { return !AssetPath.StartsWith("Assets"); } }

        public CustomSettingsEditorAsset(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath)) throw new ArgumentException("The asset path cannot be null or empty.", nameof(assetPath));

            AssetPath = assetPath;
        }

        protected override void Save(TData instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            if (HasExternalPath)
            {
                InternalEditorUtility.SaveToSerializedFileAndForget(new Object[] { instance }, AssetPath, true);
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
