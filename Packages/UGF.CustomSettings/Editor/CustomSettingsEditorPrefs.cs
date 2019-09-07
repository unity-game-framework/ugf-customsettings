using System;
using UGF.CustomSettings.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.CustomSettings.Editor
{
    public class CustomSettingsEditorPrefs<TData> : CustomSettings<TData> where TData : ScriptableObject
    {
        public string Key { get; }

        public CustomSettingsEditorPrefs(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("The prefs key cannot be null or empty.", nameof(key));

            Key = key;
        }

        protected override void Save(TData instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));

            string text = EditorJsonUtility.ToJson(instance);

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
