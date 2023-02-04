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
        
        public GameObject Get(GameObject obj) => Get(obj.name);
        public GameObject Get(GameObject obj, Vector3 position) => Get(obj.name, position);
        public GameObject Get(GameObject obj, Vector3 position, Quaternion rotation) => Get(obj.name, position, rotation);

        public T Get<T>(string name) where T : MonoBehaviour => GetObject(name).GetComponent<T>();

        public T Get<T>(string name, Vector3 position) where T : MonoBehaviour => Get(name, position).GetComponent<T>();

        public T Get<T>(string name, Vector3 position, Quaternion rotation) where T : MonoBehaviour => Get(name, position, rotation).GetComponent<T>();

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
        
        public void Pool(GameObject obj) => Pool(obj.name, obj);

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
