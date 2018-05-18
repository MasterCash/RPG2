using System.Collections;
using System.Collections.Generic;
using RPG.Items;
using UnityEngine;

namespace RPG.Inventories
{
    public class Inventory : GameObject
    {
        /// <summary>
        /// Adds an Item to the Inventory
        /// </summary>
        /// <param name="item">The Item to be added</param>
        /// <returns>True if success, false otherwise</returns>
        public bool AddItem(Item item)
        {

            if (Items.Count == InventorySize)
            {
                return false;
            } 
            Items.Add(item);
            return true;
        }

        /// <summary>
        /// Removes an Item from the Inventory
        /// </summary>
        /// <param name="item">Item to be removed, must be from the Inventory</param>
        /// <returns>True if success, false otherwise</returns>
        public bool RemoveItem(Item item)
        {
            return Items.Remove(item);
        }

        /// <summary>
        /// List of Items in the Inventory
        /// </summary>
        public List<Item> Items { get; private set; }

        /// <summary>
        /// The Size of the Inventory
        /// </summary>
        public int InventorySize { get; private set; }

        /// <summary>
        /// Increases the Inventory's Size
        /// </summary>
        /// <param name="size">Size to increase by</param>
        public void IncreaseSize(int size)
        {
            InventorySize += size;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Inventory()
        {
            Items = new List<Item>();
            InventorySize = 50;
        }
    }


}