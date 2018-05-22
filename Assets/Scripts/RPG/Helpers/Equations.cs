using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Helpers
{
    public static class Equations
    {
        private const long BaseHealth = 200;
        private const float HealthExponent = 0.9f;
        private const long BaseExp = 1000;
        private const float ExpExponent = 1.4f;
        private const long MaxLevel = 100;

        public static long DefaultSkillLevelExp(long level)
        {
            const long baseExp = 50;
            return (level * baseExp);
        }

        public static long PlayerMaxHealth(long level)
        {
            return (long)(BaseHealth * Mathf.Pow(level, HealthExponent) + BaseHealth);
        }

        public static long ExpToNextLevel(long currentLevel)
        {
            return (long)(BaseExp * Mathf.Pow(currentLevel + 1, ExpExponent));
        }

        public static bool CanLevelUp(long currentLevel)
        {
            return currentLevel < MaxLevel;

        }
    }

}

