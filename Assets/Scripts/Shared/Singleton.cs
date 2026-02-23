using UnityEngine;

namespace Shared
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance) return _instance;
                _instance = FindFirstObjectByType<T>();
                if (_instance) return _instance;
                var singletonObject = new GameObject(typeof(T).Name);
                _instance = singletonObject.AddComponent<T>();
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
                _instance = this as T;
            else if (_instance != this) Destroy(gameObject);
        }

        public virtual void OnApplicationQuit()
        {
            _instance = null;
        }
    }
}