using System.Collections;
using System.Collections.Generic;
using RPG.Helpers;
using RPG.Inventories;
using RPG.Skills;
using UnityEngine;

namespace RPG.Entities
{

    public class Entity : MonoBehaviour
    {
        [SerializeField] protected long _level;
        [SerializeField] protected long _exp;
        [SerializeField] protected Inventory _inventory;
        [SerializeField] protected string _entityName;
        [SerializeField] protected long _health;
        [SerializeField] protected long _maxHealth;

        public long Health
        {
            get { return _health; }
        }

        public string Name
        {
            get { return _entityName; }
        }


        public long MaxHealth
        {
            get { return _maxHealth; }
        }

        public long Level
        {
            get { return _level; }
        }

        public long Exp
        {
            get { return _exp; }
        }


        public Entity(Entity e)
        {
            _level = e._level;
            _exp = e._exp;
            _inventory = e._inventory;
            _health = e._health;
            _maxHealth = Equations.PlayerMaxHealth(_level);
        }

        public Entity()
        {
            _entityName = "Kirito";
            _level = 1;
            _exp = 0;
            _inventory = new Inventory();
            _maxHealth = Equations.PlayerMaxHealth(_level);
            _health = _maxHealth;
        }

        public void UpdateEntity()
        {

            while (_exp >= Equations.ExpToNextLevel(_level) && Equations.CanLevelUp(_level))
            {
                _exp -= Equations.ExpToNextLevel(_level);
                _level++;
                _health = Equations.PlayerMaxHealth(_level);

            }

            _maxHealth = Equations.PlayerMaxHealth(_level);
            if (_health > _maxHealth) _health = _maxHealth;
        }

    }


}
