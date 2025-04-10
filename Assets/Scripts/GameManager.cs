using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Components")]
    public Animator anim;
    public Transform enemy;
    public Text txtHpValue;
    public Text txtMpValue;
    public Text txtEnemyHpValue;
    public Slider sliderHp;
    public Slider sliderMp;
    public Slider sliderEnemyHp;
    public AudioSource audio1;
    public AudioSource audio2;

    [Header("Stats")]
    public int enemyHp;
    public int enemyHpMax;
    public int enemyDmg;

    public int playerHp;
    public int playerHpMax;
    public int playerMp;
    public int playerMpMax;
    public int playerAtk1;
    public int playerCost1;
    public int playerAtk2;
    public int playerCost2;

    [Header("Effects")]
    public string effectName1;
    public string effectName2;

    public bool canAttack = true;

    private void Start()
    {
        ChangePlayerInfo();
        ChangeEnemyInfo();
    }

    public void Attack1()
    {
        if (canAttack)
        {
            enemyHp -= playerAtk1;
            if (enemyHp < 0) enemyHp = 0;
            ChangeEnemyInfo();
            audio1.Play();
            anim.SetTrigger("Hit");

            GameObject effect = Resources.Load<GameObject>(effectName1);
            Instantiate(effect, enemy.position + Vector3.back, effect.transform.rotation);

            if (enemyHp <= 0)
            {
                anim.SetTrigger("Die");
                enemyHp = 0;
                canAttack = false;
                CancelInvoke();
                Invoke("GoToEnding", 2f);
                return;
            }

            Invoke("ResetDelay", 4f);
            Invoke("EnemyAttack", 2f);
            canAttack = false;
        }   
    }

    public void Attack2()
    {
        if (canAttack && playerMp >= playerCost2)
        {
            playerMp -= playerCost2;
            enemyHp -= playerAtk2;
            if (enemyHp < 0) enemyHp = 0;
            ChangePlayerInfo() ;
            ChangeEnemyInfo();
            audio2.Play();
            anim.SetTrigger("Hit");

            GameObject effect = Resources.Load<GameObject>(effectName2);
            Instantiate(effect, enemy.position + Vector3.back, effect.transform.rotation);

            if (enemyHp <= 0)
            {
                anim.SetTrigger("Die");
                enemyHp = 0;
                canAttack = false;
                CancelInvoke();
                Invoke("GoToEnding", 2f);
                return;
            }

            Invoke("ResetDelay", 4f);
            Invoke("EnemyAttack", 2f);
            canAttack = false;
        }
    }

    public void EnemyAttack()
    {
        anim.SetTrigger("Attack");
        playerHp -= enemyDmg;
        if (playerHp < 0) playerHp = 0;
        ChangePlayerInfo();
    }

    public void ResetDelay()
    {
        canAttack = true;
    }

    public void ChangeEnemyInfo()
    {
        txtEnemyHpValue.text = enemyHp.ToString();
        sliderEnemyHp.value = enemyHp * 1f / enemyHpMax;
    }

    public void ChangePlayerInfo()
    {
        txtHpValue.text = playerHp.ToString();
        sliderHp.value = playerHp * 1f / playerHpMax;

        txtMpValue.text = playerMp.ToString();
        sliderMp.value = playerMp * 1f / playerMpMax;
    }

    public void GoToEnding()
    {
        SceneManager.LoadScene("Ending");
    }
}