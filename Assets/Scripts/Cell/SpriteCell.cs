using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteCell", menuName = "Cell/Sprite Cell")]
public class SpriteCell : BaseCell
{
    /// <summary>
    /// Sprite hiển thị phía bên trên của background
    /// Nếu null sẽ không hiện gì
    /// </summary>
    [HorizontalLine]
    public Sprite sprite;
    
    /// <summary>
    /// Nằm trong foldout 'Colors'
    /// Sẽ thay đổi màu của sprite
    /// </summary>
    [Foldout("Colors")]
    public Color spriteColor = Color.white;
}