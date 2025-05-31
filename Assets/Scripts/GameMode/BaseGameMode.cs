using UnityEngine;
using Remixed2048.MergeRule;

namespace Remixed2048.GameMode
{
    public abstract class BaseGameMode : ScriptableObject
    {
        /// <summary>
        /// Mảng gồm nhiều BaseMergeRule
        /// </summary>
        public BaseMergeRule[] mergeRules;
    }
}