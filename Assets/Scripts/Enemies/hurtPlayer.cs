using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hurtPlayer : MonoBehaviour
{
    Animator anim;

    public int damage;
    public float delay;

    private float timer = 0;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if(timer < delay)
        {
            timer += Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player" && timer >= delay)
        {
            //enemy.GetComponent<Animator>().SetBool("isAttack", true);

            other.gameObject.GetComponent<HealthSys>().health -= damage;
            timer = 0;
        }
        else
        {
            //enemy.GetComponent<Animator>().SetBool("isAttack", false);
        }
    }
}
