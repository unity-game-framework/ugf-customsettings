using System;

namespace UGF.CustomSettings.Runtime
{
    public abstract partial class CustomSettings<TData>
    {
        [Obsolete("Property Data has been deprecated. Use GetData() method instead.")]
        public virtual TData Data { get { return GetData(); } }
    }
}
