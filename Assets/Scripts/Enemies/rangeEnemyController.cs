using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeEnemyController : MonoBehaviour
{
    public Transform target;

    private Rigidbody2D rB;
    
    void Start()
    {
        rB = this.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rB.rotation = angle;
    }
}
