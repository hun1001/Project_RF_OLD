using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Util
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static readonly Lazy<T> _instance =
            new Lazy<T>(() =>
            {
                T instance = FindObjectOfType(typeof(T)) as T;

                if (instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).FullName);
                    instance = obj.AddComponent(typeof(T)) as T;

                    Debug.LogWarning($"[Singleton] An instance of {typeof(T)} is needed in the scene, so '{obj}' was created.");
                }
                DontDestroyOnLoad(instance);

                return instance;
            });

        public static T Instance => _instance.Value;
    }
}
