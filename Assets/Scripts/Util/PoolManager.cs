using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Pool
{
    public class PoolManager : Singleton<PoolManager>
    {
        private Dictionary<string, Queue<GameObject>> _poolingDictionaryQueue = null;

        /// <summary>
        /// 오브젝트 가져오기
        /// </summary>
        /// <param name="address"></param>
        public GameObject Get(string address)
        {
            GameObject temp = null;

            if (_poolingDictionaryQueue.ContainsKey(address))
            {
                if (_poolingDictionaryQueue[address].Count > 0)
                {
                    temp = _poolingDictionaryQueue[address].Dequeue();
                    temp.SetActive(true);
                }
                else
                {

                }
            }
            else
            {

            }


            return temp;
        }

        public void PoolObject(string address)
        {

        }
    }
}
