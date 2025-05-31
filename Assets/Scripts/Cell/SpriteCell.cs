using UnityEngine;
using NaughtyAttributes;

namespace Remixed2048.Cell
{
    [CreateAssetMenu(fileName = "SpriteCell", menuName = "2048 Remixed/Cell/Sprite Cell")]
    public class SpriteCell : BaseCell
    {
        /// <summary>
        /// Sprite hiển thị phía bên trên của background
        /// Nếu null sẽ không hiện gì
        /// </summary>
        [HorizontalLine] public Sprite sprite;

        /// <summary>
        /// Nằm trong foldout 'Colors'
        /// Sẽ thay đổi màu của sprite
        /// </summary>
        [Foldout("Colors")] public Color spriteColor = Color.white;
    }
}