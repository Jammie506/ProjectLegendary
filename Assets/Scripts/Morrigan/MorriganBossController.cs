﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(HealthSys))]
public class MorriganBossController : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnEnable()
    {
        StartCoroutine(ChangeAttackMode());
    }

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
    public Animator myAnim;

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

    private bool rotateToPlayer = true;
    private float rotCooldown = 0;
    private bool lungeAttack = false;
    void Movement()
    {
        Vector2 getDist = myTarget.transform.position - transform.position; // GETS THE DISTANCE BETWEEN THE OBJECT AND PLAYER
        distToTarget = getDist.sqrMagnitude;    // TURNS IT INTO USEABLE FLOAT VALUE

        //    Debug.Log(distToTarget);

        if (rotateToPlayer)
        {
            transform.right = myTarget.transform.position - transform.position;     // makes the right side to look at the target (make sure all object's Z pos is on 0)
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
    float rangeMod = 0; // is added to distance ranges when attempting a lunge attack
                        //  public float timerIE = 0.1f;
    bool sideMoveRight = true;
    public bool canRetreat = false;
    public bool retreatNow = false;
    public float timeToDis;

    [Header("Effect Settings")]
    public GameObject[] fpEffSt1;
    public GameObject[] fpEffSt2;
    public GameObject[] fpEffSt3;
    public GameObject effectBurstSwitch;

    #endregion


    void AIDecision()
    {

        if (isDead == true) return;

        if (rotateToPlayer != true)
        {
            rotCooldown -= 1 * Time.deltaTime;
            if (rotCooldown < 0)
            {
                rotateToPlayer = true;
                myRB.drag = 1f;
            }
            
        }

        if (canRetreat == true && getBossHealth.health < getBossHealth.maxHealth/3) // To not let boss die in demo or mid game
        {
            retreatNow = true;
        }
        

        float distO = distOuter + rangeMod;
        float distI = distInner + rangeMod;

        if (retreatNow != true)
        {
            if (distToTarget > distO)   // Outer    // Start of follow code
            {
                myRB.AddRelativeForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Force);
                isAttackRange = true;
                myAnim.SetBool("Moving", true);
            }
            else if (distToTarget < distO && distToTarget > distI)  // Middle
            {
                isAttackRange = true;
                myAnim.SetBool("Moving", false);
                if (sideMoveRight)      // NOTE: Right is the new forward, sidemove is UP and DOWN on the local Y Axis
                {
                    myRB.AddRelativeForce((Vector2.up * speed / 2) * Time.deltaTime, ForceMode2D.Force);
                }
                else
                {
                    myRB.AddRelativeForce((Vector2.down * speed / 2) * Time.deltaTime, ForceMode2D.Force);
                }
            }
            else if (distToTarget < distI)
            {
                myRB.AddRelativeForce(Vector2.right * -speed * Time.deltaTime, ForceMode2D.Force);
                isAttackRange = false;
                myAnim.SetBool("Moving", true);
            }

        }
        else if (retreatNow == true)
        {
            myRB.AddRelativeForce(Vector2.right * -speed * Time.deltaTime, ForceMode2D.Force);
        }
        


        // Choose Attack


        if (isAttackRange && lungeAttack != true)
        {
            Debug.Log("RANGE");
            LaunchAttackPatternsRange();
        }
        else if (lungeAttack != true)
        {
            Debug.Log("MELEE");
            LaunchAttackPatternMelee(1);
        }
        else
        {
            Debug.Log("LUNGE");
            LaunchAttackPatternMelee(2);
        }


    }

    IEnumerator ChangeAttackMode()
    {
        while (true)
        {
            if(myRB != null)
            {
                myRB.drag = 1.5f;
            }

            if (sideMoveRight)
            {
                sideMoveRight = false;
            }
            else {
                sideMoveRight = true;
            }
            coolDown = 3.5f;
            attackModeRange++;
            if (attackModeRange > maxAttackMode) attackModeRange = minAttackMode; // reset to min value

            int rng = Random.Range(0,5);
            if (rng > 2)
            {
                rangeMod = 100f;
                lungeAttack = true;
            }

        //    attackModeMelee = Random.Range(1, 3);       // Melee Attacks are Randomized REVAMPED

            yield return new WaitForSeconds(7.5f);
        }
        
    }

    void LaunchAttackPatternsRange()
    {
        if (retreatNow == true) return;

        switch (attackModeRange)
        {

            case 1:
                coolDown -= 1 * Time.deltaTime;

                for (int i = 0; i < fpEffSt1.Length; i++) fpEffSt1[i].SetActive(true);
                for (int i = 0; i < fpEffSt2.Length; i++) fpEffSt2[i].SetActive(false);
                for (int i = 0; i < fpEffSt3.Length; i++) fpEffSt3[i].SetActive(false);


                if (coolDown < 0)
                {
                    for (int i = 0; i < firePointsStage1.Length; i++)      // Standard Foward Spray Attack
                    {
                        Instantiate(attacksTypes[0], firePointsStage1[i].transform.position, firePointsStage1[i].transform.rotation * Quaternion.Euler(0,0,Random.Range(-10,10)));
                    }
                    myRB.drag = 2f;
                    coolDown = 0.25f;
                }
                

                break;
                

            case 2:         // Charge up Burst

                coolDown -= 1 * Time.deltaTime;

                for (int i = 0; i < fpEffSt1.Length; i++) fpEffSt1[i].SetActive(false);
                for (int i = 0; i < fpEffSt2.Length; i++) fpEffSt2[i].SetActive(true);
                for (int i = 0; i < fpEffSt3.Length; i++) fpEffSt3[i].SetActive(false);

                if (coolDown < 0)
                {
                    
                    for (int i = 0; i < firePointsStage2.Length; i++)
                    {
                        for (int j = 0; j < 20; j++)
                        {
                            Instantiate(attacksTypes[1], firePointsStage2[i].transform.position, firePointsStage2[i].transform.rotation * Quaternion.Euler(0,0,Random.Range(-30,30)));
                        }


                    }
                    myRB.drag = 2f;
                    coolDown = 2.5f;
                }

                

                break;

            case 3:         // Accelerator Bullets (HOMING)

                coolDown -= 1 * Time.deltaTime;

                for (int i = 0; i < fpEffSt1.Length; i++) fpEffSt1[i].SetActive(false);
                for (int i = 0; i < fpEffSt2.Length; i++) fpEffSt2[i].SetActive(false);
                for (int i = 0; i < fpEffSt3.Length; i++) fpEffSt3[i].SetActive(true);

                if (coolDown < 0)
                {
                    for (int i = 0; i < firePointsStage3.Length; i++)
                    {
                        GameObject myBullet = Instantiate(attacksTypes[2], firePointsStage3[i].transform.position, firePointsStage3[i].transform.rotation);
                        myBullet.GetComponent<ProjectileSys>().myTarget = myTarget.transform;
                    }
                    myRB.drag = 3f;
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


    void LaunchAttackPatternMelee(int chooseAttack)
    {
        attackModeMelee = chooseAttack;
        switch (attackModeMelee)
        {

            case 1:

                coolDown -= 1 * Time.deltaTime;

                for (int i = 0; i < fpEffSt1.Length; i++) fpEffSt1[i].SetActive(false);
                for (int i = 0; i < fpEffSt2.Length; i++) fpEffSt2[i].SetActive(false);
                for (int i = 0; i < fpEffSt3.Length; i++) fpEffSt3[i].SetActive(false);

                if (coolDown < 1 && coolDown > 0.9)
                {
                    myAnim.SetBool("Spear", true);
                }

                if (coolDown < 0)
                {
                    GameObject sweep = Instantiate(attacksTypes[3], transform.position, transform.rotation * Quaternion.Euler(0, 0, -60));
                    sweep.transform.parent = gameObject.transform;

                    myRB.drag = 0.5f;
                    coolDown = 2.5f;
                }

                

                break;

            case 2:
                

                coolDown -= 1 * Time.deltaTime;

                for (int i = 0; i < fpEffSt1.Length; i++) fpEffSt1[i].SetActive(false);
                for (int i = 0; i < fpEffSt2.Length; i++) fpEffSt2[i].SetActive(false);
                for (int i = 0; i < fpEffSt3.Length; i++) fpEffSt3[i].SetActive(false);

                if (coolDown < 1 && coolDown > 0.9)
                {
                    myAnim.SetBool("Stab", true);
                }

                if (coolDown < 0)
                {
                    rotateToPlayer = false;
                    myRB.AddRelativeForce(Vector2.right * speed/5,ForceMode2D.Impulse);
                    GameObject lunge = Instantiate(attacksTypes[4], transform.position, transform.rotation);
                    lunge.transform.parent = gameObject.transform;

                    rangeMod = 0f;
                    lungeAttack = false;
                    rotCooldown = 2.5f;
                    coolDown = 2.5f;
                    myRB.drag = 5;
                }

                break;


        }

    }


}
