#if UNITY_EDITOR
using UnityEngine;

namespace UGF.CustomSettings.Runtime
{
    public abstract partial class CustomSettingsPlayMode<TData>
    {
        private TData m_copy;

        protected override TData OnGetData()
        {
            if (Application.isPlaying)
            {
                if (m_copy == null)
                {
                    m_copy = Object.Instantiate(base.OnGetData());
                }

                return m_copy;
            }

            DestroyCopy();

            return base.OnGetData();
        }

        public override bool CanSave()
        {
            return !Application.isPlaying;
        }

        protected override void OnDestroySettings(TData data)
        {
            base.OnDestroySettings(data);

            DestroyCopy();
        }

        private void DestroyCopy()
        {
            if (m_copy != null)
            {
                Object.DestroyImmediate(m_copy);

                m_copy = null;
            }
        }
    }
}
#endif
