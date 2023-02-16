using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class CustomGameObject : MonoBehaviour
    {
        private readonly Dictionary<ComponentType, CustomComponent<CustomGameObject>> _components = new();
        public CustomComponent<CustomGameObject> GetComponent(ComponentType type) => _components.TryGetValue(type, out var component) ? component : null;
        
        public void AddComponent(ComponentType type, CustomComponent<CustomGameObject> component)
        {
            if (_components.ContainsKey(type))
            {
                Debug.LogError($"Component {type} already exists on {gameObject.name}");
                return;
            }
            
            _components.Add(type, component);
        }
    }
}
