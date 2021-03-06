using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.CustomSettings.Runtime
{
    /// <summary>
    /// Represents custom settings which stores data at specified key in player prefs as Json representation.
    /// </summary>
    public partial class CustomSettingsPrefs<TData> : CustomSettingsPlayMode<TData> where TData : ScriptableObject
    {
        /// <summary>
        /// Gets the key which used to store data in player prefs.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Creates settings with the specified player prefs key.
        /// </summary>
        /// <param name="key">The key of the data in player prefs.</param>
        public CustomSettingsPrefs(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("The prefs key cannot be null or empty.", nameof(key));

            Key = key;
        }

        public override bool Exists()
        {
            return PlayerPrefs.HasKey(Key);
        }

        protected override void OnSaveSettings(TData data, bool force)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            string text = JsonUtility.ToJson(data);

            PlayerPrefs.SetString(Key, text);
            PlayerPrefs.Save();
        }

        protected override TData OnLoadSettings()
        {
            string text = PlayerPrefs.GetString(Key, "{}");
            var data = ScriptableObject.CreateInstance<TData>();

            JsonUtility.FromJsonOverwrite(text, data);

            return data;
        }

        protected override void OnClearSettings()
        {
            base.OnClearSettings();

            PlayerPrefs.DeleteKey(Key);
        }

        protected override void OnDestroySettings(TData data)
        {
            base.OnDestroySettings(data);

            Object.DestroyImmediate(data);
        }
    }
}
