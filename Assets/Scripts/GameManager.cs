using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image ClearPopup;
    public Image GameOverPopup;
    public Slider hpSilder;
    public Slider mpSlider;
    public Slider bossSlider;

    private int playerHP = 100;
    private int playerMP = 100;
    private int bossHP = 1000;

    public void Attack1()
    {
        bossHP -= Random.Range(10, 101);
        playerHP -= Random.Range(1, 6);
    }

    public void Attack2()
    {
        if (playerMP >= 20)
        {
            bossHP -= Random.Range(50, 151);
            playerHP -= Random.Range(11, 16);
            playerMP -= 20;
        }
    }

    private void Update()
    {
        if (playerHP < 0) { GameOverPopup.gameObject.SetActive(true); }
        if (bossHP < 0) { ClearPopup.gameObject.SetActive(true); }

        hpSilder.value = playerHP / 100f;
        mpSlider.value = playerMP / 100f;
        bossSlider.value = bossHP / 1000f;
    }
}