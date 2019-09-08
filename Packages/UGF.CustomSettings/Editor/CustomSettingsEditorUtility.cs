namespace UGF.CustomSettings.Editor
{
    /// <summary>
    /// Provides utilities to work with custom settings in editor.
    /// </summary>
    public static class CustomSettingsEditorUtility
    {
        /// <summary>
        /// Represents the default path of the settings data asset used for editor package settings.
        /// </summary>
        public const string DefaultPackageFolder = "Assets/Settings/Editor";

        /// <summary>
        /// Represents the default path of the settings data asset used for editor package settings and stored under the 'ProjectSettings' folder.
        /// </summary>
        public const string DefaultPackageExternalFolder = "ProjectSettings/Packages";
    }
}
