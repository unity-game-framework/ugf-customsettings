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
    public abstract partial class CustomSettingsPlayMode<TData> : CustomSettings<TData> where TData : ScriptableObject
    {
    }
}
