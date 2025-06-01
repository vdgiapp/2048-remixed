using UnityEngine;
using NaughtyAttributes;

namespace Remixed2048.Cell
{
    public abstract class BaseCell : ScriptableObject
    {
        [HorizontalLine]
        
        public bool customBackground;
        
        [ShowAssetPreview, ShowIf("customBackground")]
        public Sprite backgroundSprite;

        [Foldout("Colors")]
        public Color backgroundColor = Color.white;
    }
}