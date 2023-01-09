using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;

namespace Util
{
    public class AddressablesManager : Singleton<AddressablesManager>
    {
        /// <summary>
        /// 리소스를 가져오는 함수
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetResource<T>(string name)
        {
            var handle = Addressables.LoadAssetAsync<T>(name);

            handle.WaitForCompletion();

            return handle.Result;
        }

    }
}
