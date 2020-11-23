using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    
    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
