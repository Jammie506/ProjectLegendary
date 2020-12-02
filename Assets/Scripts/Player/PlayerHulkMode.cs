using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHulkMode : MonoBehaviour
{
    Animator anim;
    public int hulkCharge;
    public int maxCharge;
    public float hulkTime;
    private float hulkTimer;
    public bool isHulk;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ChargeCap();
        Hulk();
        HulkTimer();
    }

    void ChargeCap()
    {
        if (hulkCharge > maxCharge)
        {
            hulkCharge = maxCharge;
        }
    }

    void Hulk()
    {
        if (Input.GetKeyDown(KeyCode.Q) && hulkCharge == maxCharge)
        {
            isHulk = true;
            anim.SetBool("HulkMode", true);
            hulkCharge = 0;
            hulkTimer = hulkTime;
        }
    }

    void HulkTimer()
    {
        if (isHulk)
        {
            hulkTimer -= Time.deltaTime;
            if(hulkTimer <= 0)
            {
                isHulk = false;
                anim.SetBool("HulkMode", false);
            }
        }
    }
}