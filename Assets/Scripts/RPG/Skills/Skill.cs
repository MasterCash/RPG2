using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Helpers;

namespace RPG.Skills
{
    public abstract class Skill : GameObject
    {
        private long _highestLevelUnlocked;
        private const long MaxLevel = 50;
        private readonly long[] _expPerLevel;

        public long SkillId { get; private set; }

        public long Level { get; private set; }

        public long Exp { get; private set; }

        public void GainExp(long exp)
        {
            long toNextLevel = _expPerLevel[Level] - Exp;

            if (Level == _expPerLevel.Length - 1) return;

            if (exp > toNextLevel)
            {
                Exp = exp - toNextLevel;
                Level++;
            }
            else Exp += exp;

            if (Exp < 0)
            {
                Exp = 0;
            }
        }

        protected Skill()
        {
            SkillId = 0;
            _expPerLevel = new long[MaxLevel + 1];
            for (long k = 0; k < MaxLevel; k++)
            {
                _expPerLevel[k] = Equations.DefaultSkillLevelExp(k);
            }
        }

        protected Skill(long lvl, long exp) : this()
        {
            Level = lvl;
            Exp = exp;
        }

        protected Skill(long[] expPerLevel) : this(0, 0)
        {
            _expPerLevel = expPerLevel;
        }
    }
}
