using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSys : MonoBehaviour
{
    [Header("Settings")]

    public int health;
    public int maxHealth = 100;
    public bool isOnHitInvinc;            // short invincibility when hit?
    public float onHitCooldownMax = 0.5f;
    public bool isDead;

    [Header("Effect Settings")]
    public GameObject deathEffect;

    [HideInInspector]
    public float HitCool;

    public bool isHit;

    void Update()
    {
        HitCooldown();
        onDeath();
    }

    void onDeath()
    {
        if (health <= 0)
        {
            isDead = true;
        }

        if (isDead)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHulkMode>().hulkCharge++;
                if (deathEffect != null) Instantiate(deathEffect, transform.position, Quaternion.identity);

                Destroy(gameObject);    // Destroy Gameobject is placeholder
            }
            else if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadSceneAsync("GameOve");
            }
        }
    }

    void HitCooldown()
    {
        if (isHit == true) HitCool -= 1 * Time.deltaTime;

        if (HitCool <= 0) isHit = false;
    }

}