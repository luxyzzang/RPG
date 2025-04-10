using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Enemy enemy;
    public UIPlayerInfo playerUI;
    public UIEnemyInfo enemyUI;
    public AudioSource[] audios;

    public int playerHp;
    public int playerHpMax;
    public int playerMp;
    public int playerMpMax;
    public int[]  playerAtk;
    public int[]  playerCost;
    public string[] effectName;
    public bool canAttack = true;

    private void Start()
    {
        ChangeUI();
    }

    public void ChangeUI()
    {
        playerUI.ChangePlayerInfo(playerHp, playerHpMax, playerMp, playerMpMax);
        enemyUI.ChangeEnemyInfo(enemy.enemyHp, enemy.enemyHpMax);
    }

    public void Attack(int idx)
    {
        int i = idx;
        if (canAttack && playerMp >= playerCost[i])
        {
            enemy.Hit(playerAtk[i]);
            audios[i].Play();

            GameObject effect = Resources.Load<GameObject>(effectName[i]);
            Instantiate(effect, enemy.transform.position + Vector3.back, effect.transform.rotation);
            
            Invoke(nameof(ResetDelay), 3f);
            canAttack = false;
        }   
    }

    public void Hit(int damage)
    {
        playerHp -= damage;
        if (playerHp < 0) playerHp = 0;
        ChangeUI();
    }

    public void ResetDelay()
    {
        canAttack = true;
    }

    public void GoToEnding()
    {
        SceneManager.LoadScene("Ending");
    }
}