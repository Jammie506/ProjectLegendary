using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHulkMode : MonoBehaviour
{
    Animator anim;
    public int hulkCharge;
    public int maxCharge;
    public float hulkTime;
    private float hulkTimer;
    public bool isHulk;

    //post Proccess
    PostProcessVolume pp;
    public PostProcessProfile normalPP;
    public PostProcessProfile hulkPP;

    private void Start()
    {
        anim = GetComponent<Animator>();
        pp = GameObject.Find("Post Process FX").GetComponent<PostProcessVolume>();
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

            pp.profile = hulkPP;
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

                pp.profile = normalPP;
            }
        }
    }
}