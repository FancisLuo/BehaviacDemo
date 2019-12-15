using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    [CreateAssetMenu(menuName = "Content/NPC Config")]
    public class NPCConfig : ScriptableObject
    {
        [Tooltip("NPC的数量")]
        [SerializeField]
        public int EnemyCount;

        [Tooltip("每个NPC的初始位置")]
        [SerializeField]
        public List<Vector3> InitPosition;

        [Tooltip("巡逻路径，数量要与<EnemyCount>一致")]
        [SerializeField]
        public List<PatrolPath> PatrolPaths;

        public bool CheckConfig()
        {
            if(EnemyCount <= 0 || null == InitPosition || InitPosition.Count <= 0 || EnemyCount != InitPosition.Count)
            {
                return false;
            }

            return true;
        }
    }

    [System.Serializable]
    public class PatrolPath
    {
        [SerializeField]
        public List<Vector3> Route;
    }
}
