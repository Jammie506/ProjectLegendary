using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockbackAttack : MonoBehaviour
{
    public float knockbackForce;
    public float knockbackRange;
    public float knockbackCooldown;
    public bool ready;
    public int maxEnemies;

    private ContactFilter2D filter;
    public Collider2D[] enemies;
    private Coroutine cooldownRoutine;

    private void Start()
    {
        LayerMask mask = LayerMask.GetMask("Enemy");
        filter.SetLayerMask(mask);
        enemies = new Collider2D[maxEnemies];

        ready = true;
    }

    private void Update()
    {
        Knockback();
    }

    void Knockback()
    {
        if (Input.GetKeyDown(KeyCode.E) && ready)
        {
            GetEnemies();
            PushEnemies();
            CooldownTimer();
        }
    }

    void GetEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = null; //reset array
        }

        Physics2D.OverlapCircle(transform.position, knockbackRange, filter, enemies); //get all enemies in range, must be on Enemy layer
    }

    void PushEnemies()
    {
        foreach (Collider2D enemy in enemies)
        {
            if(enemy != null && enemy.CompareTag("Enemy"))
            {
                Vector2 pushDirection = enemy.transform.position - transform.position;
                Vector2 pushVector = pushDirection.normalized; //gets a normlized vector to push enemies away from player position
                Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
                rb.AddForce(pushVector * knockbackForce, ForceMode2D.Impulse); //pushes enemy rigidbody with a sudden force
            }
        }
    }

    void CooldownTimer()
    {
        ready = false;
        StartCoroutine(Cooldown(knockbackCooldown));
    }

    IEnumerator Cooldown(float time)
    {
        float timer = time;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        ready = true;
    }
}