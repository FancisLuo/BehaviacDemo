using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Example
{
    public class GameSceneManager : SingletonBase<GameSceneManager>
    {
        private string loadingSceneName;
        private AsyncOperation operation = null;

        private Action<float> progressHandler;
        private Action<bool> endActioin;
        private Action startAction;

        public void Init()
        {
            //
        }

        public void UnInit()
        {
            //
        }

        public void LoadScene(string sceneName, Action<float> progressHandler, Action<bool> endCallback, Action startCallback = null)
        {
            if(string.IsNullOrEmpty(sceneName))
            {
                throw new ArgumentNullException(nameof(sceneName));
            }

            loadingSceneName = sceneName;
            this.progressHandler = progressHandler;
            this.endActioin = endCallback;
            this.startAction = startCallback;

            StartCoroutine(DoLoadScene());
        }

        private IEnumerator DoLoadScene()
        {
            startAction?.Invoke();

            operation = SceneManager.LoadSceneAsync(loadingSceneName);
            operation.allowSceneActivation = false;

            while(operation.progress < 0.9f)
            {
                //currentProgress = operation.progress;
                progressHandler?.Invoke(operation.progress);

                yield return null;
            }
            endActioin?.Invoke(true);

            while(true)
            {
                if(Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                    break;
                }

                yield return null;
            }

            yield return null;
        }
    }
}
