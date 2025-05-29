using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "TextCell", menuName = "Cell/Text Cell")]
public class TextCell : BaseCell
{
    /// <summary>
    /// Chữ hiển thị phía bên trên của background
    /// Nếu null hoặc trống sẽ không hiện gì
    /// </summary>
    [HorizontalLine]
    public string text = "2";
    
    /// <summary>
    /// Nằm trong foldout 'Colors'
    /// Sẽ thay đổi màu của text
    /// </summary>
    [Foldout("Colors")]
    public Color textColor = Color.black;
}