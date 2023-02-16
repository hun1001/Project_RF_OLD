using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

namespace Scene
{
    public class SceneLoadManager : MonoSingleton<SceneLoadManager>
    {
        public void LoadScene(string sceneName)
        {
            PoolManager.Instance.Clear();
            StartCoroutine(LoadMyAsyncScene(sceneName));
        }
        
        public void LoadScene(int index)
        {
            PoolManager.Instance.Clear();
            StartCoroutine(LoadMyAsyncScene(index));
        }

        private IEnumerator LoadMyAsyncScene(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
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
