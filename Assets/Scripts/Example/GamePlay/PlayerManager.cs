using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Example
{
    public class PlayerManager : SingletonBase<PlayerManager>
    {
        private GameObject playerTemplate;
        private Transform managerParent;

        private Dictionary<long, Player> players = new Dictionary<long, Player>();

        private long currentPlayerID;

        public Player CurrentPlayer
        {
            get
            {
                if(players.TryGetValue(currentPlayerID, out Player player))
                {
                    return player;
                }

                return null;
            }
        }

        public void InitPlayers()
        {
            players.Clear();

            InitConfig();
            CreatePlayerManagerObj();

            InitPlayerObj();
        }

        public void UnInit()
        {
            players.Clear();
        }

        private void InitConfig()
        {
            var config = Resources.Load<CharacterConfig>(ConfigPathDefinition.PlayerConfigPath);
            if(null == config)
            {
                throw new ResourceNotFoundException("PlayerConfig", ConfigPathDefinition.PlayerConfigPath);
            }

            playerTemplate = config.CharacterTemplate;
        }

        private void CreatePlayerManagerObj()
        {
            managerParent = new GameObject("Player Manager").transform;
            managerParent.localPosition = Vector3.zero;
            managerParent.localScale = Vector3.one;
            managerParent.localRotation = Quaternion.identity;

            DontDestroyOnLoad(managerParent.gameObject);
        }

        private void InitPlayerObj()
        {
            var obj = Instantiate<GameObject>(playerTemplate, managerParent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;
            obj.SetActive(true);

            var player = obj.AddComponent<Player>();
            player.InitCharacter();

            currentPlayerID = player.GetCharacterID();
            players.Add(currentPlayerID, player);
        }
    }
}
