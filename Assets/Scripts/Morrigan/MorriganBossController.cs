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


        StartCoroutine(ChangeAttackMode());
    }
    [SerializeField]
    private float distToTarget;
    [SerializeField]
    private HealthSys getBossHealth;
    [SerializeField]
    private float myTimer = 0;
    private Rigidbody2D myRB;

    public GameObject myTarget;
    public bool isDead = false;
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
    public GameObject[] firePointMeleeAttack;
    

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
            isAttackRange = true;
        }
        else if (distToTarget < distOuter && distToTarget > distInner)  // Middle
        {
            isAttackRange = false;
        }
        else if (distToTarget < distInner)
        {
            myRB.AddRelativeForce(Vector2.right * -speed * Time.deltaTime,ForceMode2D.Force);
            isAttackRange = false;
        }
        

    }


    #region Attack Pattern Variables
    [Header("Attack Pattern Settings")]
    float coolDown = 0;                    // Use for Charge up, Continous Attacks
    float subCoolDown = 0;                         // Use for Sub Attacks
    public int attackModeRange;                          // Attack Modes: 1 = Firepoints-1, 2 = Firepoints-2 etc...      4 = Firepoints 1-3 (Fires All Stages)
    public int attackModeMelee;
    bool isAttackRange = true;
    public int minAttackMode, maxAttackMode;                                      // Set a limit when moving up boss stages (RANGE)
    int bossStage = 0;
    
  //  public float timerIE = 0.1f;

    #endregion


    void AIDecision()
    {

        if (isDead == true) return;


        // Choose Attack
        if (isAttackRange)
        {
            Debug.Log("RANGE");
            LaunchAttackPatternsRange();
        }
        else
        {
            Debug.Log("MELEE");
            LaunchAttackPatternMelee();
        }


    }

    IEnumerator ChangeAttackMode()
    {
        while (true)
        {

            attackModeRange++;
            if (attackModeRange > maxAttackMode) attackModeRange = minAttackMode; // reset to min value

            attackModeMelee = Random.Range(1, 3);       // Melee Attacks are Randomized

            yield return new WaitForSeconds(5f);
        }
        
    }

    void LaunchAttackPatternsRange()
    {


        switch (attackModeRange)
        {

            case 1:
                coolDown -= 1 * Time.deltaTime;
                if (coolDown < 0)
                {
                    for (int i = 0; i < firePointsStage1.Length; i++)      // Standard Foward Spray Attack
                    {
                        Instantiate(attacksTypes[0], firePointsStage1[i].transform.position, firePointsStage1[i].transform.rotation);
                    }
                    coolDown = 0.25f;
                }
                

                break;

            case 2:         // Charge up Burst

                coolDown -= 1 * Time.deltaTime;
                if (coolDown < 0)
                {

                    for (int i = 0; i < firePointsStage2.Length; i++)
                    {
                        for (int j = 0; j < 20; j++)
                        {
                            Instantiate(attacksTypes[1], firePointsStage2[i].transform.position, firePointsStage2[i].transform.rotation * Quaternion.Euler(0,0,Random.Range(-30,30)));
                        }


                    }

                    coolDown = 2.5f;
                }

                

                break;

            case 3:         // Accelerator Bullets

                coolDown -= 1 * Time.deltaTime;
                if (coolDown < 0)
                {
                    for (int i = 0; i < firePointsStage3.Length; i++)
                    {
                        Instantiate(attacksTypes[2], firePointsStage3[i].transform.position, firePointsStage3[i].transform.rotation);
                    }
                    coolDown = 0.5f;
                }
                

                break;      // Fires ranged attacks 1 - 3

            case 4:

                for (int i = 0; i < firePointsStage3.Length; i++)
                {

                    
                }

                break;

        }


    }


    void LaunchAttackPatternMelee()
    {

        switch (attackModeMelee)
        {

            case 1:

                GameObject sweep = Instantiate(attacksTypes[3], transform.position, transform.rotation * Quaternion.Euler(0,0,-60));
                sweep.transform.parent = gameObject.transform;

                break;

            case 2:
                GameObject lunge = Instantiate(attacksTypes[4], transform.position, transform.rotation);
                lunge.transform.parent = gameObject.transform;
                break;


        }

    }


}
