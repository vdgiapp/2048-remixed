using UnityEngine;
using NaughtyAttributes;

namespace Remixed2048.Cell
{
    [CreateAssetMenu(fileName = "TextCell", menuName = "2048 Remixed/Cell/Text Cell")]
    public class TextCell : BaseCell
    {
        [HorizontalLine]
        
        public string text = "2";

        [Foldout("Colors")]
        public Color textColor = Color.black;
    }
}