using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class GamePlayManager : MonoBehaviour
    {
        private static GamePlayManager instance = null;

        public static GamePlayManager InitGamePlayer()
        {
            if(null != instance)
            {
                return instance;
            }

            var obj = new GameObject("Game Player Manager");
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.zero;

            instance = obj.AddComponent<GamePlayManager>();
            DontDestroyOnLoad(obj);

            return instance;
        }

        private void Start()
        {
            Debug.Log("GamePlayerManager start");
            Init();
        }

        public void Init()
        {
            BehaviorTreeUtil.InitBT();
        }
    }
}
