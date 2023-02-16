using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class CustomGameObject : MonoBehaviour
    {
        private Dictionary<ComponentType, CustomComponent<CustomGameObject>> _components = new();
    }
}
