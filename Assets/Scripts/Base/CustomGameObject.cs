using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class CustomGameObject<T> : MonoBehaviour where T : CustomGameObject<T>
    {
        private readonly Dictionary<ComponentType, CustomComponent<T>> _components = new();
    }
}
