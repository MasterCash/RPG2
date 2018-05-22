using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Items
{
    public class Item : GameObject
    {
        public long ItemId { get; protected set; }
        public string Description { get; protected set; }
        public ItemType Type { get; protected set; }

    }

    public enum ItemType
    {
        Consumable, Usable, Quest, Currency, Weapon, Apparel
    }
}
