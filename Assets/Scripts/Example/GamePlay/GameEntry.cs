using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Example
{
    public class GameEntry : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Slider loadProgressBar;

        [SerializeField] private Text loadingHintText;
        [SerializeField] private Text enterHintText;
        [SerializeField] private string battleScene;

        private const string battleSceneName = "BattleScene";

        private void Awake()
        {
            if(null == startButton || null == loadProgressBar)
            {
                throw new System.Exception("UI elements is not initialized: start button");
            }

            loadingHintText.text = "";
            enterHintText.text = "";
            startButton.onClick.AddListener(HandleStartGame);
            loadProgressBar.value = 0;
        }


        // Start is called before the first frame update
        private void Start()
        {
            GamePlayManager.InitGamePlayer();
            GameSceneManager.Instance.Init();
        }

        private void OnApplicationQuit()
        {
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveAllListeners();
        }


        private void HandleStartGame()
        {
            GameSceneManager.Instance.LoadScene(string.IsNullOrEmpty(battleScene)? battleSceneName: battleScene,
                                                HandleProgress,
                                                HandleLoadingEnd,
                                                null);
        }

        private void HandleProgress(float progress)
        {
            loadProgressBar.value = progress;

            loadingHintText.text = $"loading...{(int)(progress * 100)}/100";
        }

        private void HandleLoadingEnd(bool obj)
        {
            if(obj)
            {
                loadProgressBar.value = 100;
                loadingHintText.text = "loading...100/100";
                enterHintText.text = "按任意键继续";
            }
        }
    }
}
