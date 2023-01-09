using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Pool
{
    public class PoolManager : Singleton<PoolManager>
    {
        private Dictionary<string, Queue<GameObject>> _poolingDictionaryQueue = null;

        public GameObject Get(string name)
        {
            GameObject temp = null;

            if (_poolingDictionaryQueue.ContainsKey(name))
            {
                if (_poolingDictionaryQueue[name].Count > 0)
                {
                    temp = _poolingDictionaryQueue[name].Dequeue();
                }
                else
                {
                    temp = AddressablesManager.Instance.GetResource<GameObject>(name);
                }
            }
            else
            {
                _poolingDictionaryQueue.Add(name, new Queue<GameObject>());
                temp = AddressablesManager.Instance.GetResource<GameObject>(name);
            }

            temp.SetActive(true);

            return temp;
        }

        public void PoolObject(string name, GameObject obj)
        {
            obj.SetActive(false);

            if (_poolingDictionaryQueue.ContainsKey(name))
            {
                _poolingDictionaryQueue[name].Enqueue(obj);
            }
            else
            {
                _poolingDictionaryQueue.Add(name, new Queue<GameObject>());
                _poolingDictionaryQueue[name].Enqueue(obj);
            }
        }
    }
}
