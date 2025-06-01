using UnityEngine;

namespace Remixed2048
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance) return _instance;
                _instance = FindObjectOfType<T>(); // _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance) return _instance;
                Debug.LogWarning($"[MonoSingleton<{typeof(T)}>] Instance not found in scene. Creating one automatically.");
                var go = new GameObject($"{typeof(T)}");
                _instance = go.AddComponent<T>();
                // DontDestroyOnLoad(go);
                return _instance;
            }
        }
        
        public static bool Exists() => (_instance);
        
        protected virtual void Awake()
        {
            if (!_instance) _instance = this as T;
            else if (_instance != this)
            {
                Debug.LogWarning($"[MonoSingleton<{typeof(T)}>] Duplicate instance detected. Destroying the new one.");
                Destroy(gameObject);
            }
        }
        
        protected virtual void OnDestroy()
        {
            if (_instance == this) _instance = null;
        }
        
        protected void Reset()
        {
            _instance = null;
        }
    }
}