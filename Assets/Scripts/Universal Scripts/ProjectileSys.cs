using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class ProjectileSys : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        myCollider = GetComponent<Collider2D>();
        if (isMultiHit) myCollider.isTrigger = true;
        else myCollider.isTrigger = false;

    }

    private Collider2D myCollider;

    [Header("Settings")]
    public int damage = 10;
    public float speed = 5f;
    public float lifetime = 5f;
    public float delay = 0;     //  stays still until delay is up
    public bool isHoming = false;       // Tracks and chases target
    public bool isMultiHit = false;             // Will not despawn on hit
    public GameObject subProjectile;                    // Fires projectile out of main projectile
    public bool isExplosive = false;                            // Does exactly what it says
    public int explosiveDamage = 5;
    public float radius = 5;

    [Header("Effects")]
    public GameObject[] effectOnHit;


    // Update is called once per frame
    void FixedUpdate()
    {

        Movement();
        lifetime -= 1 * Time.deltaTime;

        if (lifetime <= 0) Destroy(gameObject);

    }

    void Movement()
    {

        Rigidbody2D myRB = GetComponent<Rigidbody2D>();
        myRB.velocity = transform.right * speed;

    }


    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Enemy"))
        {
            HealthSys otherHP = collision.collider.GetComponent<HealthSys>();

            otherHP.health -= damage;
            Debug.Log("HIT");

        }

        

        for (int i = 0; i < effectOnHit.Length; i++)
        {
            if (effectOnHit != null)
            Instantiate(effectOnHit[i],transform.position,Quaternion.identity);
        }

        Destroy(gameObject);

    }

    private void OnTriggerStay2D(Collider2D other)  // will pass through targets
    {
        if (isMultiHit)
        {

            if (other.CompareTag("Player") || other.CompareTag("Enemy"))
            {

                HealthSys otherHP = other.GetComponent<HealthSys>();

                otherHP.health -= damage;

            }




        }
    }

    private void Explode()
    {
        Vector2 myPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(myPos,radius);
        foreach (Collider2D hit in colliders)
        {

            if (hit.CompareTag("Player") || hit.CompareTag("Enemy"))
            {

               HealthSys otherHP = hit.GetComponent<HealthSys>();

                otherHP.health -= explosiveDamage;
               
            }

        }

    }
    

    private void OnDestroy()
    {
        for (int i = 0; i < effectOnHit.Length; i++)
        {

            Instantiate(effectOnHit[i], transform.position, Quaternion.identity);
        }
    }
}
