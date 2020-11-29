using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSys : MonoBehaviour
{
    public int health;
    public bool isDead;

    void Update()
    {
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
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadSceneAsync("GameOve");
            }
        }
    }
}