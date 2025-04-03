using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image img;
    public Button btn;
    public Slider silder;
    public Text text;

    private void Start()
    {
        img.color = Color.white;
        btn.interactable = true;
        silder.value = silder.maxValue / 2;
        text.fontStyle = FontStyle.Bold;
    }
}