using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement pMove;
    PlayerHulkMode hulk;

    private Transform attackSpawn;
    public GameObject swipe, stab;

    public int swipeDamage, stabDamage, hulkDamage; //how much damage each attack type should do
    public float swipeInterval, stabInterval, hulkInterval; //how long between each attack, for before we rig up animatioin behaviours
    public bool isAttacking; //prevents attack spamming

    private void Start()
    {
        anim = GetComponent<Animator>();
        pMove = GetComponent<PlayerMovement>();
        hulk = GetComponent<PlayerHulkMode>();
        attackSpawn = transform.GetChild(0).transform;
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
            isAttacking = true;
            anim.SetBool("Swipe", true);
            //when animation is right, call damage
            Damage(swipeDamage);
            //when animation finished, allow attacks again
        }
        else if (Input.GetButtonDown("Fire2") && !isAttacking && !pMove.dodging && !hulk.isHulk)
        {
            //play stab animation
            isAttacking = true;
            anim.SetBool("Stab", true);
            //when animation is right, call damage
            Damage(stabDamage);
            //when animation finished, allow attacks again
        }
        else if(Input.GetButtonDown("Fire1") && !isAttacking && !pMove.dodging && hulk.isHulk)
        {
            //play hulk attack animation
            isAttacking = true;
            //when animation is right, call damage
            Damage(hulkDamage);
            //when animation is finished, allow attacks again
        }
    }

    public void Damage(int damage)
    {
        //send damage values to enemy health script
        if(damage == swipeDamage)
        {
            GameObject swipeAttack = Instantiate(swipe, attackSpawn.position, attackSpawn.rotation);
            swipeAttack.GetComponent<ProjectileSys>().damage = damage;
        }
        else if (damage == stabDamage)
        {
            GameObject stabAttack = Instantiate(stab, attackSpawn.position, attackSpawn.rotation);
            stabAttack.GetComponent<ProjectileSys>().damage = damage;
        }
        else if(damage == hulkDamage)
        {
            //hulk attack
        }
    }
}