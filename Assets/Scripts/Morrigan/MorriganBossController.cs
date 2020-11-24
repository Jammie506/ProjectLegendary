using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(HealthSys))]
public class MorriganBossController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        getBossHealth = GetComponent<HealthSys>();
        myRB = GetComponent<Rigidbody2D>();
        myTarget = GameObject.FindGameObjectWithTag("Player");
    }
    [SerializeField]
    private float distToTarget;
    [SerializeField]
    private HealthSys getBossHealth;
    [SerializeField]
    private float myTimer = 0;
    private Rigidbody2D myRB;

    public GameObject myTarget;

    #region Settings

    [Header("Movement Settings")]
    public float speed = 250;
    public float distInner = 0, distOuter = 0;  // Sets the optimal range for boss to attack and/or move to
    public float distMod = 0;

    [Header("Sense Settings")]
    public bool isTargetVis;
    public bool isTargetHear;
    public bool isTargetClose;

    [Header("Attack Settings")]
    public GameObject[] attacksTypes;
    public GameObject[] firePointsStage1;
    public GameObject[] firePointsStage2;
    public GameObject[] firePointsStage3;

    public GameObject[] firePointSubAttack;
    private int attackMode;                 // Attack Modes: 1 = Firepoints-1, 2 = Firepoints-2 etc...      4 = Firepoints 1-3 (Fires All Stages)

    #endregion

    // Update is called once per frame
    void FixedUpdate()
    {

        Movement();
        AIDecision();

    }

    void Movement()
    {
        Vector2 getDist = myTarget.transform.position - transform.position; // GETS THE DISTANCE BETWEEN THE OBJECT AND PLAYER
        distToTarget = getDist.sqrMagnitude;    // TURNS IT INTO USEABLE FLOAT VALUE

    //    Debug.Log(distToTarget);

        transform.right = myTarget.transform.position - transform.position;     // makes the right side to look at the target (make sure all object's Z pos is on 0)

        if (distToTarget > distOuter)   // Outer
        {
            myRB.AddRelativeForce(Vector2.right * speed * Time.deltaTime,ForceMode2D.Force);
        }
        else if (distToTarget < distOuter && distToTarget > distInner)  // Middle
        {

        }
        else if (distToTarget < distInner)
        {
            myRB.AddRelativeForce(Vector2.right * -speed * Time.deltaTime,ForceMode2D.Force);
        }
        

    }

    void AIDecision()
    {

    }

    void LaunchAttackPatterns()
    {


        switch (attackMode)
        {

            case 1:

                break;

            case 2:

                break;

            case 3:

                break;

            case 4:

                break;



        }


    }


}
