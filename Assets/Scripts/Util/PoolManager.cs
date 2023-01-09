using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class PoolManager : Singleton<PoolManager>
    {
        private Dictionary<string, Queue<GameObject>> _objectDictionaryQueue = null;
    }
}
