using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Util
{
    public class SceneLoadManager : MonoSingleton<SceneLoadManager>
    {
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadMyAsyncScene(sceneName));
        }
        public void LoadScene(int index)
        {
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
