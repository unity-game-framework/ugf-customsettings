using System;
using UnityEngine;

namespace UGF.CustomSettings.Runtime
{
    /// <summary>
    /// Represents abstract custom settings which provide access to settings data.
    /// </summary>
    /// <remarks>
    /// Inherit this class to implement settings load and save behaviour.
    /// </remarks>
    public abstract class CustomSettings<TData> where TData : ScriptableObject
    {
        /// <summary>
        /// Event triggered after data saving completed.
        /// </summary>
        public event Action Saved;

        /// <summary>
        /// Event triggered after data loading completed.
        /// </summary>
        public event Action Loaded;

        /// <summary>
        /// Event triggered after data clear completed.
        /// </summary>
        public event Action Cleared;

        /// <summary>
        /// Gets the settings data.
        /// </summary>
        /// <remarks>
        /// If the settings data not yet loaded, the loading will be triggered.
        /// </remarks>
        public virtual TData Data
        {
            get
            {
                if (m_data == null)
                {
                    LoadSettings();
                }

                return m_data;
            }
        }

        private TData m_data;

        /// <summary>
        /// Determines whether settings data can be saved.
        /// </summary>
        public virtual bool CanSave()
        {
            return true;
        }

        /// <summary>
        /// Determines whether settings data exists.
        /// </summary>
        public virtual bool Exists()
        {
            return true;
        }

        /// <summary>
        /// Saves settings data, if available.
        /// </summary>
        /// <remarks>
        /// <see cref="CanSave"/> determines whether settings can be saved.
        /// </remarks>
        public void SaveSettings()
        {
            if (CanSave())
            {
                OnSaveSettings(m_data);

                Saved?.Invoke();
            }
        }

        /// <summary>
        /// Loads settings data.
        /// </summary>
        public void LoadSettings()
        {
            m_data = OnLoadSettings();

            if (m_data == null)
            {
                throw new ArgumentException($"{typeof(TData).Name}: no settings data found.");
            }

            Loaded?.Invoke();
        }

        /// <summary>
        /// Clears settings data file or storage.
        /// </summary>
        public void ClearSettings()
        {
            OnClearSettings();

            Cleared?.Invoke();
        }

        /// <summary>
        /// Override this method to implement saving of the data.
        /// </summary>
        /// <param name="data">The data to save.</param>
        protected virtual void OnSaveSettings(TData data)
        {
        }

        /// <summary>
        /// Override this method to implement loading of the data.
        /// </summary>
        protected virtual TData OnLoadSettings()
        {
            return null;
        }

        /// <summary>
        /// Override this method to implement clear of the data.
        /// </summary>
        protected virtual void OnClearSettings()
        {
        }
    }
}
