using System;

namespace UGF.CustomSettings.Runtime
{
    public abstract partial class CustomSettings<TData>
    {
        /// <summary>
        /// Override this method to implement saving of the data.
        /// </summary>
        /// <param name="data">The data to save.</param>
        [Obsolete("Method OnSaveSettings(T data) has been deprecated. Use OnSaveSettings(T data, bool force) instead.")]
        protected virtual void OnSaveSettings(TData data)
        {
            OnSaveSettings(data, true);
        }
    }
}
