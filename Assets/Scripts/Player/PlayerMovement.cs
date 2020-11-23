using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //components
    private Animator anim;

    //variables
    public float speed;
    public bool movementStyle;
    private float horizontal;
    private float vertical;

    private void Update()
    {
        if (movementStyle)
        {
            MovementVectoredAxes();
        }
        else
        {
            MovementDualAxes();
        }
    }

    void MovementDualAxes()
    {
        //get axes
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //translate
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);
        transform.Translate(0, vertical * speed * Time.deltaTime, 0);
    }

    void MovementVectoredAxes()
    {
        //get axes
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //Normalized Vector
        Vector3 dualVector = new Vector3(horizontal, vertical, 0);
        Vector3 direction = dualVector.normalized;

        //translate
        transform.Translate(direction * speed*Time.deltaTime);
    }
}