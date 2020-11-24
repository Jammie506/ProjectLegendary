using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sling : MonoBehaviour
{
    public GameObject rock;
    private float timer = 5;
    public float fireTime;
    public GameObject enemy;
    
    void Start()
    {
        enemy.GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireTime)
        {
            Instantiate(rock, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
