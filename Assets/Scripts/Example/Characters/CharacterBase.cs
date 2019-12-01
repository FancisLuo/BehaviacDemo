using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class CharacterBase : MonoBehaviour, ICharacter
    {
        protected long characterID;

        protected GameObject characterObject;
        protected Dictionary<long, GameObject> characterMap = new Dictionary<long, GameObject>();

        private bool initialized;

        public CharacterBase()
        {
            initialized = false;
            characterMap.Clear();
        }

        public long GetCharacterID()
        {
            if(!initialized)
            {
                throw new System.Exception("Character is not initialized");
            }

            return characterID;
        }

        public virtual void InitCharacter()
        {
            characterID = IDCreator.CreateID();

            initialized = true;
        }

        public virtual void UnInit()
        {
            initialized = false;
        }

        public virtual void Destroy()
        {
            initialized = false;
            characterMap.Clear();
        }

        public bool GetObjectByID(long id, out GameObject character)
        {
            character = null;
            return characterMap.TryGetValue(id, out character);
        }
    }
}
