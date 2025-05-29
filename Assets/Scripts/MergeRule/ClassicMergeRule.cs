using System.Collections.Generic;
using UnityEngine;

// Hợp nhất những ô khác loại hoặc cùng loại
// VD: TextCell+SpriteCell -> TextCell, SpriteCell+SpriteCell -> TextCell

[CreateAssetMenu(fileName = "ClassicMergeRule", menuName = "Merge Rule/Classic")]
public class ClassicMergeRule : BaseMergeRule
{
    public Dictionary<(BaseCell, BaseCell), BaseCell> rules { get; private set; } = new();
}