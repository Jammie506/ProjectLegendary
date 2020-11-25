using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class ProjectileSys : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Physics2D.IgnoreLayerCollision(10,10);
        myCollider = GetComponent<Collider2D>();
        if (isMultiHit) myCollider.isTrigger = true;
        else myCollider.isTrigger = false;

        if (randomSpeed)
        {
            speed = Random.Range(minSpeed, maxSpeed);
        }

    }

    private Collider2D myCollider;

    [Header("Settings")]
    public int damage = 10;
    public float speed = 5f;
    public bool randomSpeed = false;    // Overrides standard speed with a random value
    public float minSpeed = 1f, maxSpeed = 5f;
    public float lifetime = 5f;
    public float delay = 0;     //  stays still until delay is up
    public bool isHoming = false;       // Tracks and chases target
    public float homingPower = 1f;
    public bool isMultiHit = false;             // Will not despawn on hit
    public GameObject subProjectile;                    // Fires projectile out of main projectile
    public bool isExplosive = false;                            // Does exactly what it says
    public int explosiveDamage = 5;
    public float radius = 5;
    public bool isRampUp;                                                           // Accelerates overtime
    public float rampStrength = 1f;
    private float overtime = 0;

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
        if (gameObject.GetComponent<Rigidbody2D>() == true)
        {
            Rigidbody2D myRB = GetComponent<Rigidbody2D>();

            if (isRampUp != true && myRB != null && delay <= 0)
            {
                myRB.velocity = transform.right * speed;
            }
            else
            {
                overtime += rampStrength * Time.deltaTime;
                myRB.velocity = transform.right * overtime;

            }
        }
        


    //    float step = homingPower * Time.deltaTime;
        #region homing WIP
        /*
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (isHoming)
        {

            Vector2 direction = Vector2.Scale(target.transform.position, transform.position);

            float angleDiff = Vector2.Angle(transform.right,direction);

         //   float velocityAdjustmentScalar = (m_DegreesPerSecond * Mathf.Deg2Rad) - m_Rigidbody.angularVelocity.magnitude;

            if (angleDiff < 1.5 && angleDiff > -1.5)
            {
                myRB.AddTorque(-myRB.angularVelocity, ForceMode2D.Force);
            }
            else
            {
                myRB.AddTorque(myRB.angularVelocity, ForceMode2D.Force);
            }


        }// For Enemy Projectiles Only!
        */
        #endregion
    }


    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 10) return;       // ANYTHING with the layer Projectile is ignored by the object


        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Enemy"))
        {


            HealthSys otherHP = collision.collider.GetComponent<HealthSys>();

            otherHP.health -= damage;
            Debug.Log("HIT");

        }

        

        for (int i = 0; i < effectOnHit.Length; i++)
        {
            if (effectOnHit != null)
            Instantiate(effectOnHit[i],transform.position,Quaternion.identity * Quaternion.Euler(90,0,0));
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
        /*
        for (int i = 0; i < effectOnHit.Length; i++)
        {
            
            Instantiate(effectOnHit[i], transform.position, transform.localRotation * Quaternion.Euler(90,0,0));
        }
        */
    }
}
