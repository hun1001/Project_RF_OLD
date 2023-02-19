using UnityEngine;

namespace Base
{
    public abstract class CustomComponent<T> : MonoBehaviour where T : CustomGameObject<T>
    {
        private T _instance = null;

        protected T Instance => _instance ??= GetComponent<T>();
    }
}
