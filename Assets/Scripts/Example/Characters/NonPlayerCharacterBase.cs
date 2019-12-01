using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace Example
{
    public abstract class NonPlayerCharacterBase : CharacterBase
    {
        private NavMeshAgent characterAgent;
        private NonPlayerCharacterAgent npcAgent;

        private string treeName;

        public override void InitCharacter()
        {
            base.InitCharacter();
            characterAgent = gameObject.GetComponent<NavMeshAgent>();

            InitAgent();

            InitCharacterAgent();
        }

        private void InitAgent()
        {
            treeName = "AiMonster";
        }

        private void InitCharacterAgent()
        {
            if(null == characterAgent)
            {
                throw new System.Exception("characterAgent is not initialized");
            }

            if(string.IsNullOrEmpty(treeName))
            {
                throw new System.Exception("set the tree name first");
            }

            npcAgent = new NonPlayerCharacterAgent();
            npcAgent.InitAgent(this);

            if(npcAgent.btload(treeName))
            {
                npcAgent.btsetcurrent(treeName);
            }
        }

        public void MoveRandom()
        {
            characterAgent.Move(Vector3.one);
        }
    }
}
