using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public static class ConfigPathDefinition
    {
        /// <summary>
        /// player角色配置的路径，resources目录下
        /// </summary>
        public static readonly string PlayerConfigPath = "Config/CharacterData/PlayerConfig";

        /// <summary>
        /// NPC角色配置的路径，resources目录下
        /// </summary>
        public static readonly string NPCConfigPath = "Config/CharacterData/NPCConfig";
        
        /// <summary>
        /// NPC配置，个数，初始位置
        /// </summary>
        public static readonly string NPCInitConfigPath = "Config/CharacterData/NPCInitConfig";


    }
}
