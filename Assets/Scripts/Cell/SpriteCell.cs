using UnityEngine;
using NaughtyAttributes;

namespace Remixed2048.Cell
{
    [CreateAssetMenu(fileName = "SpriteCell", menuName = "2048 Remixed/Cell/Sprite Cell")]
    public class SpriteCell : BaseCell
    {
        [HorizontalLine]
        public Sprite sprite;

        [Foldout("Colors")]
        public Color spriteColor = Color.white;
    }
}