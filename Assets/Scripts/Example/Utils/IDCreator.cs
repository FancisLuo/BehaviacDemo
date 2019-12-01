using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public static class IDCreator
    {
        private static long IDSeed = 0;
        private const long defaultID = 88888888L;


        public static long CreateID()
        {
            long id = defaultID + IDSeed;
            ++IDSeed;
            return id;
        }
    }
}
