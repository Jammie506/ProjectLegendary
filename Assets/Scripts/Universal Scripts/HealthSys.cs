using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int health;
    public bool isDead;


    // Update is called once per frame
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

    }
}
