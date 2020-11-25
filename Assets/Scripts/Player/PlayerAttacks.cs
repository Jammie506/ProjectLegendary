using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement pMove;
    PlayerHulkMode hulk;

    public int swipeDamage, stabDamage, hulkDamage; //how much damage each attack type should do
    public float swipeInterval, stabInterval, hulkInterval; //how long between each attack, for before we rig up animatioin behaviours
    public bool isAttacking; //prevents attack spamming

    private void Start()
    {
        anim = GetComponent<Animator>();
        pMove = GetComponent<PlayerMovement>();
        hulk = GetComponent<PlayerHulkMode>();
    }

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking && !pMove.dodging && !hulk.isHulk)
        {
            //play swipe animation
            anim.SetBool("Swipe", true);
            //when animation is right, call damage
            //when animation finished, allow attacks again
            //anim.SetBool("Swipe", false);
        }
        else if (Input.GetButtonDown("Fire2") && !isAttacking && !pMove.dodging && !hulk.isHulk)
        {
            //play stab animation
            anim.SetBool("Stab", true);
            //when animation is right, call damage
            //when animation finished, allow attacks again
            //anim.SetBool("Stab", false);
        }
        else if(Input.GetButtonDown("Fire1") && !isAttacking && !pMove.dodging && hulk.isHulk)
        {
            //play hulk attack animation
            //when animation is right, call damage
            //when animation is finished, allow attacks again
        }
    }

    public void Damage(int attackType)
    {
        int damage; //sets how much damage should be done by this attack

        switch (attackType)
        {
            case 1:
                damage = swipeDamage;
                break;
            case 2:
                damage = stabDamage;
                break;
            case 3:
                damage = hulkDamage;
                break;
        }

        //send damage values to enemy health script
    }
}