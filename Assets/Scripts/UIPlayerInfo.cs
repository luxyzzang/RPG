using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfo : MonoBehaviour
{
    public Text txtHpValue;
    public Text txtMpValue;
    public Slider sliderHp;
    public Slider sliderMp;

    public void ChangePlayerInfo(int hp, int hpMax, int mp, int mpMax)
    {
        txtHpValue.text = hp.ToString();
        sliderHp.value = hp * 1f / hpMax;

        txtMpValue.text = mp.ToString();
        sliderMp.value = mp * 1f / mpMax;
    }
}