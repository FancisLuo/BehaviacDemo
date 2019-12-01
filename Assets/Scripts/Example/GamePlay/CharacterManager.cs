using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Example
{
    public class CharacterManager : SingletonBase<CharacterManager>
    {
        private GameObject npcTemplate;
        private int npcCount;
        private List<Vector3> npcsInitPosition = new List<Vector3>();

        private Transform characterParent;

        private Dictionary<long, CharacterBase> characters = new Dictionary<long, CharacterBase>();

        public void InitCharacters()
        {
            characters.Clear();
            npcsInitPosition.Clear();

            InitConfig();
            CreateCharacterManagerObj();
            CreateCharacters();
        }

        private void InitConfig()
        {
            var config = Resources.Load<CharacterConfig>(ConfigPathDefinition.NPCConfigPath);
            if(null == config)
            {
                throw new ResourceNotFoundException("NPCConfig", ConfigPathDefinition.NPCConfigPath);
            }

            npcTemplate = config.CharacterTemplate;

            GameObjectFactory.Instance.InitFactory(npcTemplate);

            var initConfig = Resources.Load<NPCConfig>(ConfigPathDefinition.NPCInitConfigPath);
            if(null == initConfig || !initConfig.CheckConfig())
            {
                throw new ResourceNotFoundException("NPCInitConfig", ConfigPathDefinition.NPCInitConfigPath);
            }

            npcCount = initConfig.EnemyCount;
            npcsInitPosition.AddRange(initConfig.InitPosition);
        }

        private void CreateCharacters()
        {
            for(var i = 0; i < npcCount; ++i)
            {
                var obj = GameObjectFactory.Instance.CreateObject(characterParent, npcsInitPosition[i]);
                var character = AddCharacterToObject<NonPlayerCharacter>(obj);
                character.InitCharacter();
                characters.Add(character.GetCharacterID(), character);
            }
        }

        private void CreateCharacterManagerObj()
        {
            characterParent = new GameObject("Character Manager").transform;
            characterParent.localPosition = Vector3.zero;
            characterParent.localScale = Vector3.one;
            characterParent.localRotation = Quaternion.identity;

            DontDestroyOnLoad(characterParent.gameObject);
        }

        public void UnInit()
        {
            if(null != characters)
            {
                foreach(var character in characters)
                {
                    character.Value.UnInit();
                }

                characters.Clear();
            }
        }

        private void OnDestroy()
        {
            characters.Clear();
        }

        private TCharacter AddCharacterToObject<TCharacter>(GameObject obj) where TCharacter: CharacterBase
        {
            return obj.AddComponent<TCharacter>();
        }
    }
}
