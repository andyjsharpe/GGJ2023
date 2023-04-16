using TMPro;
using UnityEngine;

public class LineClick : MonoBehaviour
{
    public static Color original = Color.black;
    public static Color clicked = new Color(209, 142, 8);
    [SerializeField] TextMeshProUGUI textMeshPro;
    bool changed = false;

    public void ChangeColor()
    {
        if (!changed)
        {
            changed = true;
            textMeshPro.color = clicked;
            FindObjectOfType<BookGenerator>().READING_COUNT++;
        }
    }
}
