using System;
using System.IO;
using UnityEngine;

namespace UGF.CustomSettings.Runtime
{
    /// <summary>
    /// Represents custom settings which stores data at specified file path as Json representation.
    /// </summary>
    public class CustomSettingsFile<TData> : CustomSettingsPlayMode<TData> where TData : ScriptableObject
    {
        /// <summary>
        /// Gets the path of the file.
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Creates settings with the specified file path.
        /// </summary>
        /// <param name="filePath">The path of the file to store settings data.</param>
        public CustomSettingsFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("The file path cannot be null or empty.", nameof(filePath));

            FilePath = filePath;
        }

        public override bool Exists()
        {
            return File.Exists(FilePath);
        }

        protected override void OnSaveSettings(TData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            string directory = Path.GetDirectoryName(FilePath);

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string text = JsonUtility.ToJson(data, true);

            File.WriteAllText(FilePath, text);
        }

        protected override TData OnLoadSettings()
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

        protected override void OnClearSettings()
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }
    }
}
