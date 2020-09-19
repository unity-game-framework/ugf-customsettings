using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

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

            CustomSettingsUtility.CheckAndCreateDirectory(FilePath);

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
            base.OnClearSettings();

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }

        protected override void OnDestroySettings(TData data)
        {
            base.OnDestroySettings(data);

            Object.DestroyImmediate(data);
        }
    }
}
