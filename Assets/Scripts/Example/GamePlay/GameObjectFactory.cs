using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{

    public class GameObjectFactory: SingletonBase<GameObjectFactory>
    {
        private GameObject template;

        public void InitFactory(GameObject template)
        {
            this.template = template;
        }

        public GameObject CreateObject(Transform parent, Vector3 initPos)
        {
            if(null == parent)
            {
                throw new System.ArgumentNullException(nameof(parent));
            }

            var obj = Instantiate<GameObject>(template, parent);
            obj.transform.localPosition = initPos;

            return obj;
        }

        public void Cleanup()
        {
            template = null;
        }
    }
}
