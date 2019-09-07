using System;
using System.IO;
using UnityEngine;

namespace UGF.CustomSettings.Runtime
{
    public class CustomSettingsFile<TData> : CustomSettingsPlayMode<TData> where TData : ScriptableObject
    {
        public string FilePath { get; }

        public CustomSettingsFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("The file path cannot be null or empty.", nameof(filePath));

            FilePath = filePath;
        }

        protected override void Save(TData instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            string directory = Path.GetDirectoryName(FilePath);

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string text = JsonUtility.ToJson(instance, true);

            File.WriteAllText(FilePath, text);

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.ImportAsset(FilePath);
#endif
        }

        protected override TData Load()
        {
            string text = "{}";
            var data = ScriptableObject.CreateInstance<TData>();

            if (File.Exists(FilePath))
            {
                text = File.ReadAllText(FilePath);
            }

            JsonUtility.FromJsonOverwrite(text, data);

            return data;
        }
    }
}
