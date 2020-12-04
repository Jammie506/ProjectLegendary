using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //components
    private Animator anim;
    PlayerHulkMode hulk;
    PlayerSFX PS;
    Collider2D myCollider;

    //variables
    public float speed, hulkSpeed;
    public float dodgeSpeed, dodgeTime;

    public bool movementStyle;

    public bool moving;
    public bool dodging;
    private float horizontal, vertical;
    private Vector2 direction;

    private void Start()
    {
        anim = GetComponent<Animator>();
        hulk = GetComponent<PlayerHulkMode>();
        PS = GetComponent<PlayerSFX>();
        myCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        MoveCheck();
        Dodge();
        AnimCheck();

        if (!dodging)
        {
            Movement();
            DirectionalRotation();
        }
    }

    void Movement()
    {
        MovementRotational();
    }

    void MovementDualAxes()
    {
        //get axes
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //translate
        if (!hulk.isHulk)
        {
            transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);
            transform.Translate(0, vertical * speed * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(horizontal * hulkSpeed * Time.deltaTime, 0, 0);
            transform.Translate(0, vertical * hulkSpeed * Time.deltaTime, 0);
        }

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
        if (!hulk.isHulk)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(direction * hulkSpeed * Time.deltaTime);
        }
        
    }

    void MovementRotational()
    {
        //get axes
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            //Normalized Vector
            Vector2 dualVector = new Vector2(horizontal, vertical);
            direction = dualVector.normalized;

            //translate
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    void DirectionalRotation()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion quat = Quaternion.Euler(0, 0, angle + 90);
        transform.rotation = quat;
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
            myCollider.enabled = false;
            StartCoroutine(DodgeMove(dodgeTimer));
            PS.PlayDodge();
        }
    }

    IEnumerator DodgeMove(float timer)
    {
        float dodgeRoutine = timer;

        while(dodgeRoutine > 0)
        {
            dodgeRoutine -= Time.deltaTime;
            transform.Translate(Vector2.down * dodgeSpeed * Time.deltaTime);
            yield return null;
        }

        dodging = false;
        yield return new WaitForSeconds(0.1f);
        myCollider.enabled = true;
    }

    void AnimCheck()
    {
        if (moving)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }

        if (dodging)
        {
            anim.SetBool("Dodging", true);
        }
        else
        {
            anim.SetBool("Dodging", false);
        }
    }
}