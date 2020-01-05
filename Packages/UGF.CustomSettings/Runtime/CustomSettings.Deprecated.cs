using System;

namespace UGF.CustomSettings.Runtime
{
    public abstract partial class CustomSettings<TData>
    {
        /// <summary>
        /// Saves settings data, if available.
        /// </summary>
        /// <remarks>
        /// <see cref="CanSave"/> determines whether settings can be saved.
        /// </remarks>
        [Obsolete("Save has been deprecated. Use SaveSettings instead.")]
        public void Save()
        {
            SaveSettings();
        }

        /// <summary>
        /// Invoked to preform saving of the specified data.
        /// </summary>
        /// <param name="data">The settings data to save.</param>
        [Obsolete("Save has been deprecated. Use OnSaveSettings instead.")]
        protected virtual void Save(TData data)
        {
        }

        /// <summary>
        /// Invoked to perform settings data loading.
        /// </summary>
        [Obsolete("Load has been deprecated. Use OnLoadSettings instead.")]
        protected virtual TData Load()
        {
            return null;
        }
    }
}
