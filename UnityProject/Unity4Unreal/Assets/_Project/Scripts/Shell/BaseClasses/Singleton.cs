using UnityEngine;

namespace Unreal.Shell
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance;

        /// <summary>
        /// Awake is used to initialize the singleton. Use <see cref = "SingletonAwake()"/> instead
        /// </summary>
        protected void Awake() {
            if(Instance != null && Instance != this) Destroy(this);
            else{
                Instance = (T)this;
                SingletonAwake();
            }
        }

        protected virtual void SingletonAwake(){ }
    }
}
