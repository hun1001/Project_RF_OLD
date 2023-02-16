using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class CustomGameObject : MonoBehaviour
    {
        private Dictionary<ComponentType, CustomComponent<CustomGameObject>> _components = new();
        public CustomComponent<CustomGameObject> GetComponent(ComponentType type) => _components.TryGetValue(type, out var component) ? component : null;
        
    }
}
