using UnityEngine;
using NaughtyAttributes;

namespace Remixed2048.Cell
{
    [CreateAssetMenu(fileName = "TextCell", menuName = "2048 Remixed/Cell/Text Cell")]
    public class TextCell : BaseCell
    {
        /// <summary>
        /// Chữ hiển thị phía bên trên của background
        /// Nếu null hoặc trống sẽ không hiện gì
        /// </summary>
        [HorizontalLine] public string text = "2";

        /// <summary>
        /// Nằm trong foldout 'Colors'
        /// Sẽ thay đổi màu của text
        /// </summary>
        [Foldout("Colors")] public Color textColor = Color.black;
    }
}