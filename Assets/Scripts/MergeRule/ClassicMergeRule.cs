using System.Collections.Generic;
using Remixed2048.Cell;
using UnityEngine;

// Hợp nhất những ô khác loại hoặc cùng loại
// VD: TextCell+SpriteCell -> TextCell, SpriteCell+SpriteCell -> TextCell

namespace Remixed2048.MergeRule
{
    [CreateAssetMenu(fileName = "ClassicMergeRule", menuName = "2048 Remixed/Merge Rule/Classic")]
    public class ClassicMergeRule : BaseMergeRule
    {
        public Dictionary<(BaseCell, BaseCell), BaseCell> rules { get; private set; } = new();
    }
}