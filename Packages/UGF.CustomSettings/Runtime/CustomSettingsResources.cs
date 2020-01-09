using System;
using UnityEngine;

namespace UGF.CustomSettings.Runtime
{
    /// <summary>
    /// Represents custom settings stored at resources folder as settings data asset.
    /// </summary>
    /// <remarks>
    /// A calling of the 'SaveSettings' and 'ClearSettings' method has no effect.
    /// </remarks>
    public class CustomSettingsResources<TData> : CustomSettingsPlayMode<TData> where TData : ScriptableObject
    {
        /// <summary>
        /// Gets the path of the asset at resources folder.
        /// </summary>
        public string ResourcesPath { get; }

        /// <summary>
        /// Creates settings with the specified path of the asset at resources folder.
        /// </summary>
        /// <param name="resourcesPath">The path of the asset at resources folder.</param>
        public CustomSettingsResources(string resourcesPath)
        {
            if (string.IsNullOrEmpty(resourcesPath)) throw new ArgumentException("The resources path cannot be null or empty.", nameof(resourcesPath));

            ResourcesPath = resourcesPath;
        }

        public override bool Exists()
        {
            return Resources.Load<TData>(ResourcesPath) != null;
        }

        protected override void OnSaveSettings(TData data)
        {
        }

        protected override TData OnLoadSettings()
        {
            var data = Resources.Load<TData>(ResourcesPath);

            if (data == null)
            {
                throw new ArgumentException($"{typeof(TData).Name}: no settings data found at resources path: '{ResourcesPath}'.");
            }

            return data;
        }
    }
}
