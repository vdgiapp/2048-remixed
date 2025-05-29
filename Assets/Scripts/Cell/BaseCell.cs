using NaughtyAttributes;
using UnityEngine;

public abstract class BaseCell : ScriptableObject
{
    /// <summary>
    /// Có sử dụng custom background không?
    /// Nếu không thì sử dụng màu backgroundColor
    /// Nếu có thì sử dụng backgroundSprite
    /// </summary>
    [HorizontalLine]
    public bool customBackground;
    
    /// <summary>
    /// Hiển thị khi customBackground được check trong Editor
    /// Sẽ sử dụng backgroundSprite với màu backgroundColor
    /// </summary>
    [ShowAssetPreview, ShowIf("customBackground")]
    public Sprite backgroundSprite;
    
    /// <summary>
    /// Nằm trong foldout 'Colors'
    /// Sẽ thay đổi màu của background hoặc backgroundSprite
    /// </summary>
    [Foldout("Colors")]
    public Color backgroundColor = Color.white;
}