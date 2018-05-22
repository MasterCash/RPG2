using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RPG
{
    [Serializable]
    public class GameObject
    {
        private static long _idCount;
        private static readonly HashSet<GameObject> Ids = new HashSet<GameObject>();

        public long Id { get; private set; }

        public string Name { get; protected set; }

        public Vector3? Location { set; get; }

        public GameObject()
        {
            Id = ++_idCount;
            Location = null;
            Ids.Add(this);
        }

        public GameObject(string objName, Vector3? loc = null) : this()
        {
            Name = objName;
            Location = loc;
        }

        public GameObject(GameObject obj)
        {
            Id = obj.Id;
            Name = obj.Name;
            Location = obj.Location;
        }

        ~GameObject() 
        {
            Ids.Remove(this);
        }
    }
}
