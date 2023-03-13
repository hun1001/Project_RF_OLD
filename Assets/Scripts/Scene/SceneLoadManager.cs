using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

namespace Scene
{
    public class SceneLoadManager : MonoSingleton<SceneLoadManager>
    {
        public void LoadScene(int index)
        {
            PoolManager.Instance.Clear();
            EventManager.ClearEvent();
            StartCoroutine(LoadMyAsyncScene(index));
        }

        public void LoadScene(SceneType type)
        {
            PoolManager.Instance.Clear();
            EventManager.ClearEvent();
            StartCoroutine(LoadMyAsyncScene((int)type));
        }

        public void RestartScene()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex);
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
