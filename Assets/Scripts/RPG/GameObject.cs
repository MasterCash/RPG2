using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{

    public class GameObject : Object
    {
        private static long _idCount = 0;
        private readonly long _id;
        private static readonly HashSet<GameObject> ids = new HashSet<GameObject>();

        public long ID
        {
            get { return _id; }
        }

        public Vector3? Location { set; get; }

        public GameObject()
        {
            _id = ++_idCount;
            Location = null;
            ids.Add(this);
        }

        public GameObject(string objName, Vector3? loc = null)
        {
            name = objName;
            Location = loc;
            _id = ++_idCount;
            ids.Add(this);
        }

        ~GameObject() 
        {
            ids.Remove(this);
        }
    }
}
