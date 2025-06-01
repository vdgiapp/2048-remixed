using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Remixed2048
{
    sealed class GlobalPrefabLoader : MonoBehaviour
    {
        public static Object GlobalObject { get; private set; }
        public static bool IsLoading { get; private set; }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void LoadGlobalObjectPrefab()
        {
            if (GlobalObject) return;
            
            var existing = GameObject.Find("2048RemixedGlobal");
            if (existing)
            {
                GlobalObject = existing;
                return;
            }
            
            IsLoading = true;
            var handle = Addressables.LoadAssetAsync<GameObject>("Assets/RawAssets/Prefabs/2048RemixedGlobal.prefab");
            handle.Completed += (task =>
            {
                IsLoading = false;

                if (task.Status != AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError("[GlobalPrefabLoader] Failed to load 2048RemixedGlobal prefab from Addressables.");
                    return;
                }

                var prefab = task.Result;
                GlobalObject = Instantiate(prefab);
                GlobalObject.name = "2048RemixedGlobal";
                DontDestroyOnLoad(GlobalObject);
            });
        }
    }
}