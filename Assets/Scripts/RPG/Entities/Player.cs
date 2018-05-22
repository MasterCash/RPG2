using System.Collections;
using System.Collections.Generic;
using RPG.Helpers;
using RPG.Skills;
using RPG.Inventories;
using UnityEngine;

namespace RPG.Entities
{

    public class Player : Entity
    {
        private List<Skill> _skills;

        public Player() : base()
        {
            _skills = new List<Skill>();
        }

        public Player(Player p) : base((Entity)p)
        {
            _skills = p._skills;
        }

        public void Damage(long damage)
        {
            _health -= (long)Mathf.Clamp(damage, 0, _health);
        }

        public void Heal(long heal)
        {
            _health += (long)Mathf.Clamp(heal, 0, _maxHealth - _health);
        }

        public void LevelUp()
        {
            _exp = Equations.ExpToNextLevel(99);
            UpdateEntity();
        }

        public void LevelDown()
        {
            _level--;
            UpdateEntity();
        }

        private void FixedUpdate()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)) Damage(20);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) Heal(20);
            else if (Input.GetKeyDown(KeyCode.Alpha3)) LevelUp();
            else if (Input.GetKeyDown(KeyCode.Alpha4)) LevelDown();

        }
    }


}
