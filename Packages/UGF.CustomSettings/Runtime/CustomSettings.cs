using System;
using UnityEngine;

namespace UGF.CustomSettings.Runtime
{
    public abstract class CustomSettings<TData> where TData : ScriptableObject
    {
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

        public void Save()
        {
            if (CanSave())
            {
                Save(m_data);
            }
        }

        protected virtual bool CanSave()
        {
            return true;
        }

        protected abstract void Save(TData data);
        protected abstract TData Load();
    }
}
