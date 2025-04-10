using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    public Animator anim;
    public Animation cube;

    void Start()
    {
        anim.SetBool("isJump", false);
        anim.SetTrigger("doJump");
    }

    void Update()
    {
        
    }

    public void Attack()
    {
        anim.SetTrigger("doAttack");
    }

    public void Damage()
    {
        anim.SetTrigger("doDamage");
    }

    public void CubeAnimation()
    {
        cube.Play("CubeScaling");
    }
}
