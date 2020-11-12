using System;

namespace UGF.CustomSettings.Runtime
{
    public partial class CustomSettingsPrefs<TData>
    {
        /// <summary>
        /// Gets the value that determines whether to force player prefs saving each time when settings saving performed.
        /// </summary>
        [Obsolete("Property ForceSave has been deprecated.")]
        public bool ForceSave { get; }

        /// <summary>
        /// Creates settings with the specified player prefs key.
        /// </summary>
        /// <param name="key">The key of the data in player prefs.</param>
        /// <param name="forceSave">The value that determines whether to save player prefs when settings saving performed.</param>
        [Obsolete("Constructor CustomSettingsPrefs(string key, bool forceSave) has been deprecated.")]
        public CustomSettingsPrefs(string key, bool forceSave)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("The prefs key cannot be null or empty.", nameof(key));

            Key = key;
            ForceSave = forceSave;
        }
    }
}
