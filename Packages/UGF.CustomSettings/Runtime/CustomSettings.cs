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
                    m_data = Load();

                    if (m_data == null)
                    {
                        throw new ArgumentException($"{typeof(TData).Name}: no settings data found.");
                    }
                }

                return m_data;
            }
        }

        private TData m_data;

        /// <summary>
        /// Saves settings data, if available.
        /// </summary>
        /// <remarks>
        /// <see cref="CanSave"/> determines whether settings can be saved.
        /// </remarks>
        public void Save()
        {
            if (CanSave())
            {
                Save(m_data);
            }
        }

        /// <summary>
        /// Determines whether settings data can be saved.
        /// </summary>
        /// <returns></returns>
        public virtual bool CanSave()
        {
            return true;
        }

        /// <summary>
        /// Invoked to preform saving of the specified data.
        /// </summary>
        /// <param name="data">The settings data to save.</param>
        protected abstract void Save(TData data);

        /// <summary>
        /// Invoked to perform settings data loading.
        /// </summary>
        protected abstract TData Load();
    }
}
