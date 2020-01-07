using System;
using UnityEngine;

namespace UGF.CustomSettings.Runtime
{
    /// <summary>
    /// Represents custom settings which stores data at specified key in player prefs as Json representation.
    /// </summary>
    public class CustomSettingsPrefs<TData> : CustomSettingsPlayMode<TData> where TData : ScriptableObject
    {
        /// <summary>
        /// Gets the key which used to store data in player prefs.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets the value that determines whether to force player prefs saving each time when settings saving performed.
        /// </summary>
        public bool ForceSave { get; }

        /// <summary>
        /// Creates settings with the specified player prefs key.
        /// </summary>
        /// <param name="key">The key of the data in player prefs.</param>
        /// <param name="forceSave">The value that determines whether to save player prefs when settings saving performed.</param>
        public CustomSettingsPrefs(string key, bool forceSave = false)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("The prefs key cannot be null or empty.", nameof(key));

            Key = key;
            ForceSave = forceSave;
        }

        public override bool Exists()
        {
            return PlayerPrefs.HasKey(Key);
        }

        protected override void OnSaveSettings(TData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            string text = JsonUtility.ToJson(data);

            PlayerPrefs.SetString(Key, text);

            if (ForceSave)
            {
                PlayerPrefs.Save();
            }
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
            PlayerPrefs.DeleteKey(Key);
        }
    }
}
