using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager game;
    public UIEnemyInfo enemyUI;
    public Animator anim;

    public int enemyHp;
    public int enemyHpMax;
    public int enemyDmg;

    private const string attackTrigger = "Attack";
    private const string hitTrigger = "Hit";
    private const string dieTrigger = "Attack";

    public void EnemyAttack()
    {
        anim.SetTrigger(attackTrigger);
        game.Hit(enemyDmg);
    }

    public void Hit(int damage)
    {
        enemyHp -= damage;
        if (enemyHp < 0) enemyHp = 0;
        anim.SetTrigger(hitTrigger);
        game.ChangeUI();

        if (enemyHp <= 0)
        {
            anim.SetTrigger(dieTrigger);
            enemyHp = 0;
            game.canAttack = false;
            CancelInvoke();
            game.Invoke(nameof(game.GoToEnding), 2f);
            return;
        }

        Invoke(nameof(EnemyAttack), 1.5f);
    }
}