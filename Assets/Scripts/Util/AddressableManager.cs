using UnityEngine;
using UnityEngine.AddressableAssets;

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

        public Material GetMaterial(string name)
        {
            var handle = Addressables.LoadAssetAsync<Material>(name);

            handle.WaitForCompletion();

            return handle.Result;
        }
    }
}
