using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class SingletonBase<TSingleton> : MonoBehaviour where TSingleton: MonoBehaviour
    {
        private static TSingleton instance;

        public static TSingleton Instance
        {
            get
            {
                if(Application.isPlaying && null == instance)
                {
                    GameObject obj = GameObject.Find("Singleton Object");
                    if(null == obj)
                    {
                        obj = new GameObject("Singleton Object");
                    }
                    DontDestroyOnLoad(obj);

                    instance = obj.GetComponent<TSingleton>();
                    if(null == instance)
                    {
                        instance = obj.AddComponent<TSingleton>();
                    }
                }

                return instance;
            }
        }
    }
}