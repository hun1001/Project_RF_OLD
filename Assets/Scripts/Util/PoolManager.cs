using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Util
{
    public class PoolManager : Singleton<PoolManager>
    {
        private Dictionary<string, Queue<GameObject>> _poolingDictionaryQueue = new();

        public GameObject Get(string name)
        {
            return GetObject(name);
        }

        public GameObject Get(string name, Vector3 position)
        {
            var temp = GetObject(name);
            temp.transform.position = position;

            return temp;
        }

        public GameObject Get(string name, Vector3 position, Quaternion rotation)
        {
            var temp = GetObject(name);
            temp.transform.position = position;
            temp.transform.rotation = rotation;

            return temp;
        }

        public void Pool(string name, GameObject obj)
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

        private GameObject GetObject(string name)
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
                    temp = GameObject.Instantiate(AddressablesManager.Instance.GetResource<GameObject>(name), null);
                }
            }
            else
            {
                _poolingDictionaryQueue.Add(name, new Queue<GameObject>());
                temp = GameObject.Instantiate(AddressablesManager.Instance.GetResource<GameObject>(name), null);
            }

            temp.SetActive(true);

            return temp;
        }
    }
}
