using System.Collections;
using System.Collections.Generic;
using RPG.Items;
using UnityEngine;

namespace RPG.Inventories
{
    public class EntityInventory : Inventory
    {
        public Hashtable Armor { get; protected set; }

        public EntityInventory()
        {
            for(ArmorType k = ArmorType.Head; k <= ArmorType.Feet; k++)
            {
                Armor.Add(k, null);
            }
            
        }

    }

    public enum ArmorType
    {
        Head,
        Neck,
        Chest,
        Hands,
        LeftHand,
        RightHand,
        Belt,
        Legs,
        Feet
        
    }
}
