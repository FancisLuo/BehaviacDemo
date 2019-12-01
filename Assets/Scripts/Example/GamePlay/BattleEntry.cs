using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    using UnityStandardAssets.SceneUtils;

    public class BattleEntry : MonoBehaviour
    {
        [SerializeField] private PlaceTargetWithMouse placeTarget;

        // Start is called before the first frame update
        void Start()
        {
            PlayerManager.Instance.InitPlayers();
            placeTarget.setTargetOn = PlayerManager.Instance.CurrentPlayer.gameObject;

            CharacterManager.Instance.InitCharacters();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
