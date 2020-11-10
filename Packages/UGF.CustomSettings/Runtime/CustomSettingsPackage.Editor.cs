#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.CustomSettings.Runtime
{
    public partial class CustomSettingsPackage<TData>
    {
        public override bool Exists()
        {
            return File.Exists(AssetPath);
        }

        protected override void OnSaveSettings(TData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            if (Exists())
            {
                EditorUtility.SetDirty(data);
            }
            else
            {
                CustomSettingsUtility.CheckAndCreateDirectory(AssetPath);

                AssetDatabase.CreateAsset(data, AssetPath);
                AssetDatabase.ImportAsset(AssetPath);
            }

            AssetDatabase.SaveAssets();
        }

        protected override TData OnLoadSettings()
        {
            if (!Exists())
            {
                var data = ScriptableObject.CreateInstance<TData>();

                OnSaveSettings(data);
            }

            return base.OnLoadSettings();
        }

        protected override void OnClearSettings()
        {
            base.OnClearSettings();

            if (Exists())
            {
                AssetDatabase.MoveAssetToTrash(AssetPath);
            }
        }

        protected override void OnDestroySettings(TData data)
        {
            base.OnDestroySettings(data);

            if (!Exists())
            {
                Object.DestroyImmediate(data);
            }
        }
    }
}
#endif
