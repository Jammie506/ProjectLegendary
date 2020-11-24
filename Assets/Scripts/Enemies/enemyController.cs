using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class enemyController : MonoBehaviour
{
    private Animator enemyAnim;
    public Transform target;

    private Rigidbody2D rB;
    
    [SerializeField] private float speed;
    
    //Set minRange to whatever the Enemy's size is so they dont get shoved around!!! - J
    [SerializeField] private float maxRange;
    [SerializeField] private float minRange;
    
    void Start()
    {
        enemyAnim = GetComponent<Animator>();

        rB = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rB.rotation = angle;
        
        if (Vector3.Distance((target.position), transform.position) <= maxRange 
            && Vector3.Distance((target.position), transform.position) >= minRange)
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        enemyAnim.SetBool("isMoving", true);
        enemyAnim.SetFloat( "moveX", (target.position.x - transform.position.x));
        enemyAnim.SetFloat( "moveY", (target.position.y - transform.position.y));
        
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed*Time.deltaTime);
    }
}
