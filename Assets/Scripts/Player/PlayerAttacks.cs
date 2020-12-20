using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement pMove;
    PlayerHulkMode hulk;

    private Transform attackSpawn;
    public GameObject swipe, stab, smash;

    public int swipeDamage, stabDamage, hulkDamage; //how much damage each attack type should do
    public int hulkHealing;
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
        }
        else if (Input.GetButtonDown("Fire2") && !isAttacking && !pMove.dodging && !hulk.isHulk)
        {
            //play stab animation
            isAttacking = true;
            anim.SetBool("Stab", true);
        }
        else if(Input.GetButtonDown("Fire1") && !isAttacking && !pMove.dodging && hulk.isHulk)
        {
            //play hulk attack animation
            isAttacking = true;
            anim.SetBool("Smash1", true);
        }
        else if (Input.GetButtonDown("Fire2") && !isAttacking && !pMove.dodging && hulk.isHulk)
        {
            //play hulk attack animation
            isAttacking = true;
            anim.SetBool("Smash2", true);
        }
        //animation behaviour scripts handle the rest
    }

    public void Damage(int damage)
    {
        //send damage values to enemy health script
        if(damage == swipeDamage)
        {
            GameObject swipeAttack = Instantiate(swipe, attackSpawn.position, attackSpawn.rotation);
            swipeAttack.GetComponent<ProjectileSys>().damage = damage;
            swipeAttack.transform.parent = gameObject.transform;
        }
        else if (damage == stabDamage)
        {
            GameObject stabAttack = Instantiate(stab, attackSpawn.position, attackSpawn.rotation);
            stabAttack.GetComponent<ProjectileSys>().damage = damage;
            stabAttack.transform.parent = gameObject.transform;
        }
        else if(damage == hulkDamage)
        {
            //hulk attack
            GameObject hulkAttack = Instantiate(smash, attackSpawn.position, attackSpawn.rotation);
            hulkAttack.GetComponent<ProjectileSys>().damage = damage;
            hulkAttack.transform.parent = gameObject.transform;
            HulkHeal();

        }
    }

    void HulkHeal()
    {
        GetComponent<HealthSys>().health += hulkHealing;
    }
}