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
    }
    [SerializeField]
    private float distToTarget;
    [SerializeField]
    private HealthSys getBossHealth;

    [Header("Sense Setting")]
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

    // Update is called once per frame
    void FixedUpdate()
    {

        Movement();
        AIDecision();

    }

    void Movement()
    {

    }

    void AIDecision()
    {

    }

    void LaunchAttacks()
    {


    }


}
