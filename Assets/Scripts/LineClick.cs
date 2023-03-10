using TMPro;
using UnityEngine;

public class LineClick : MonoBehaviour
{
    public static Color original = Color.black;
    public static Color clicked = Color.green;
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
