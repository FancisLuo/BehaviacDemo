using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    [CreateAssetMenu(menuName = "Content/NPC Config")]
    public class NPCConfig : ScriptableObject
    {
        [SerializeField]
        public int EnemyCount;

        [SerializeField]
        public List<Vector3> InitPosition;

        public bool CheckConfig()
        {
            if(EnemyCount <= 0 || null == InitPosition || InitPosition.Count <= 0 || EnemyCount != InitPosition.Count)
            {
                return false;
            }

            return true;
        }
    }
}
