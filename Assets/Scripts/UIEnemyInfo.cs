using UnityEngine;
using UnityEngine.UI;

public class UIEnemyInfo : MonoBehaviour
{
    public Text txtEnemyHpValue;
    public Slider sliderEnemyHp;

    public void ChangeEnemyInfo(int hp, int hpMax)
    {
        txtEnemyHpValue.text = hp.ToString();
        sliderEnemyHp.value = hp * 1f / hpMax;
    }
}