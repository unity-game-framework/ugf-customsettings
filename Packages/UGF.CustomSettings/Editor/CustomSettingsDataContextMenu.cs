using System;
using UGF.CustomSettings.Runtime;
using UnityEditor;

namespace UGF.CustomSettings.Editor
{
    internal static class CustomSettingsDataContextMenu
    {
        public static event Action<CustomSettingsData> ClearMenu;
        public static event Func<CustomSettingsData, bool> ClearValidate;

        [MenuItem("CONTEXT/CustomSettingsData/Delete", false, 2000)]
        private static void DeleteMenu(MenuCommand menuCommand)
        {
            if (ClearMenu != null)
            {
                var data = (CustomSettingsData)menuCommand.context;

                ClearMenu(data);
            }
        }

        [MenuItem("CONTEXT/CustomSettingsData/Delete", true, 2000)]
        private static bool DeleteValidate(MenuCommand menuCommand)
        {
            if (ClearValidate != null)
            {
                var data = (CustomSettingsData)menuCommand.context;
                bool result = ClearValidate(data);

                return result;
            }

            return false;
        }
    }
}
