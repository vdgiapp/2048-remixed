using UnityEngine;

public abstract class BaseGameMode : ScriptableObject
{
    /// <summary>
    /// Mảng gồm nhiều BaseMergeRule
    /// </summary>
    public BaseMergeRule[] mergeRules;
}