using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class hurtEnemy : MonoBehaviour
{
    //Rework of the same script on the enemy, remove the timer so as not to interfere with the controller script
    //but left the Animator references there, the script should be placed on a CHILD of the player, ie, their weapon,
    //and the the player parent object should be placed in the public gameObject - J
    
    public float timer = 5;
    //public GameObject player;

    private void Start()
    {
        //player.GetComponent<Animator>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy" && timer >= 5)
        {
            //player.GetComponent<Animator>().SetBool("isAttack", true);
            other.gameObject.GetComponent<enemyHealth>().HurtEnemy(10);
            timer = 0;
        }
        else
        {
            //player.GetComponent<Animator>().SetBool("isAttack", false);
        }
    }
}
