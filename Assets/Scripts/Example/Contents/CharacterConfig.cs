using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    [CreateAssetMenu(menuName = "Content/Character Config")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField]
        public GameObject CharacterTemplate;
    }
}
