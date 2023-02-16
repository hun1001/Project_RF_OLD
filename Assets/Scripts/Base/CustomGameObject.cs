using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class CustomGameObject<T> : MonoBehaviour where T : CustomGameObject<T>
    {
        private readonly Dictionary<ComponentType, CustomComponent<T>> _components = new();
        // public CustomComponent<T> GetCustomComponent(ComponentType type) => _components.TryGetValue(type, out var component) ? component : null;
        //
        // public void AddComponent(ComponentType type, CustomComponent<T> component)
        // {
        //     if (_components.ContainsKey(type))
        //     {
        //         Debug.LogError($"Component {type} already exists on {gameObject.name}");
        //         return;
        //     }
        //     
        //     _components.Add(type, component);
        // }
    }
}
