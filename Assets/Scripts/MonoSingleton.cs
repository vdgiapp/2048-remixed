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
                _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance) return _instance;
                _instance = new GameObject().AddComponent<T>();
                _instance.gameObject.name = _instance.GetType().Name;
                return _instance;
            }
        }
        
        public static bool Exists() => (_instance);
        
        protected void Reset()
        {
            _instance = null;
        }
    }
}