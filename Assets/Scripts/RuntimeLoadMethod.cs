using UnityEngine;
using UnityEngine.UI;

namespace Remixed2048
{
    sealed class RuntimeLoadMethod : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void LoadGlobalPrefab()
        {
            var prefab = Resources.Load("Prefabs/2048RemixedGlobal");
            if (!prefab) return;
            var instance = Instantiate(prefab);
            instance.name = "2048RemixedGlobal";
            DontDestroyOnLoad(instance);
        }
    }
}