using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class projectileStuff : MonoBehaviour
{
    private Rigidbody2D rB;
    [SerializeField] private float speed;
    
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rB.velocity = transform.forward * speed;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<healthManager>().HurtPlayer(10);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
