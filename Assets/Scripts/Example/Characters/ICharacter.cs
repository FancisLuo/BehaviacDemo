using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public interface ICharacter
    {
        long GetCharacterID();

        void InitCharacter();
    }
}
