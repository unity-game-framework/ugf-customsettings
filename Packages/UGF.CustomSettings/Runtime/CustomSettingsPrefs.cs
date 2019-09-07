using System;
using UnityEngine;

namespace UGF.CustomSettings.Runtime
{
    public class CustomSettingsPrefs<TData> : CustomSettingsPlayMode<TData> where TData : ScriptableObject
    {
        public string Key { get; }
        public bool ForceSave { get; }

        public CustomSettingsPrefs(string key, bool forceSave = false)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("The prefs key cannot be null or empty.", nameof(key));

            Key = key;
            ForceSave = forceSave;
        }

        protected override void Save(TData instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            string text = JsonUtility.ToJson(instance);

            PlayerPrefs.SetString(Key, text);

            if (ForceSave)
            {
                PlayerPrefs.Save();
            }
        }

        protected override TData Load()
        {
            string text = PlayerPrefs.GetString(Key, "{}");
            var data = ScriptableObject.CreateInstance<TData>();

            JsonUtility.FromJsonOverwrite(text, data);

            return data;
        }
    }
}
