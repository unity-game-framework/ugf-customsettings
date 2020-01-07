using System;
using UGF.CustomSettings.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.CustomSettings.Editor
{
    /// <summary>
    /// Represents custom settings which stores data at specified key in editor prefs as Json representation.
    /// </summary>
    public class CustomSettingsEditorPrefs<TData> : CustomSettings<TData> where TData : ScriptableObject
    {
        /// <summary>
        /// Gets the key which used to store data in editor prefs.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Creates settings with the specified editor prefs key.
        /// </summary>
        /// <param name="key">The key of the data in editor prefs.</param>
        public CustomSettingsEditorPrefs(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("The prefs key cannot be null or empty.", nameof(key));

            Key = key;
        }

        public override bool Exists()
        {
            return EditorPrefs.HasKey(Key);
        }

        protected override void OnSaveSettings(TData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            string text = EditorJsonUtility.ToJson(data);

            EditorPrefs.SetString(Key, text);
        }

        protected override TData OnLoadSettings()
        {
            string text = EditorPrefs.GetString(Key, "{}");
            var target = ScriptableObject.CreateInstance<TData>();

            EditorJsonUtility.FromJsonOverwrite(text, target);

            return target;
        }

        protected override void OnClearSettings()
        {
            EditorPrefs.DeleteKey(Key);
        }
    }
}
