using UnityEngine;

namespace UGF.CustomSettings.Runtime
{
    /// <summary>
    /// Represents abstract custom settings which creates copy to make available interacting with data in play mode without losing data.
    /// </summary>
    /// <remarks>
    /// In play mode returns copy of the original settings data and saving not available.
    /// In build just returns the original settings data.
    /// </remarks>
    public abstract class CustomSettingsPlayMode<TData> : CustomSettings<TData> where TData : ScriptableObject
    {
        public override TData Data
        {
            get
            {
#if UNITY_EDITOR
                if (Application.isPlaying)
                {
                    if (m_copy == null)
                    {
                        m_copy = Object.Instantiate(base.Data);
                    }

                    return m_copy;
                }

                if (m_copy != null)
                {
                    Object.DestroyImmediate(m_copy);

                    m_copy = null;
                }
#endif
                return base.Data;
            }
        }

#if UNITY_EDITOR
        private TData m_copy;
#endif

        public override bool CanSave()
        {
            return !Application.isPlaying;
        }
    }
}
