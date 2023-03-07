using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

namespace Scene
{
    public class SceneLoadManager : MonoSingleton<SceneLoadManager>
    {
        public void LoadScene(int index) => LoadScene((SceneType)index);

        public void LoadScene(SceneType type)
        {
            PoolManager.Instance.Clear();
            StartCoroutine(LoadMyAsyncScene((int)type));
        }

        private IEnumerator LoadMyAsyncScene(int index)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}
