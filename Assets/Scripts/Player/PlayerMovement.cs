using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //components
    private Animator anim;

    //variables
    public float speed;
    public float dodgeSpeed;
    public float dodgeTime;

    public bool movementStyle;

    private bool moving;
    private bool dodging;
    private float horizontal;
    private float vertical;
    private Vector2 direction;

    private void Update()
    {
        MoveCheck();
        Dodge();

        if (!dodging)
        {
            Movement();
        }
    }

    void Movement()
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

        //dodge Vector
        Vector2 dualVector = new Vector2(horizontal, vertical);
        direction = dualVector.normalized;
    }

    void MovementVectoredAxes()
    {
        //get axes
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //Normalized Vector
        Vector2 dualVector = new Vector2(horizontal, vertical);
        direction = dualVector.normalized;

        //translate
        transform.Translate(direction * speed*Time.deltaTime);
    }

    void MoveCheck()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }

    void Dodge()
    {
        if (Input.GetButtonDown("Jump") && !dodging && moving)
        {
            dodging = true;
            float dodgeTimer = dodgeTime;
            StartCoroutine(DodgeMove(dodgeTimer));
        }
    }

    IEnumerator DodgeMove(float timer)
    {
        float dodgeRoutine = timer;

        while(dodgeRoutine > 0)
        {
            dodgeRoutine -= Time.deltaTime;
            transform.Translate(direction * dodgeSpeed * Time.deltaTime);
            yield return null;
        }

        dodging = false;
    }
}