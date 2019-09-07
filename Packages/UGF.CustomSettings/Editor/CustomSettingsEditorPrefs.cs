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

        protected override void Save(TData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            string text = EditorJsonUtility.ToJson(data);

            EditorPrefs.SetString(Key, text);
        }

        protected override TData Load()
        {
            string text = EditorPrefs.GetString(Key, "{}");
            var target = ScriptableObject.CreateInstance<TData>();

            EditorJsonUtility.FromJsonOverwrite(text, target);

            return target;
        }
    }
}
