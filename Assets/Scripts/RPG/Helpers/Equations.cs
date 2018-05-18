using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Helpers
{
    public static class Equations
    {
        public static long DefaultSkillLevelExp(long level)
        {
            const long baseExp = 50;
            return (level * baseExp);
        }
    }

}

