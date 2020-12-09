using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitTrig : MonoBehaviour
{   // If Target Health is lowered such as player's health, if its lowered than its newly registered value it will trigger


    #region  Variables

    [Header("Settings")]
    public Image myFlashImage;
    public Vlambeer myVlambeer;
    public GameObject myHitEffect;
    public AudioClip myHitAudio;

    private HealthSys myObjHealth;
    private AudioSource mySource;
    int newHPValue;
    #endregion

    private void Start()
    {
        myObjHealth = GetComponent<HealthSys>();
        mySource = GetComponent<AudioSource>();

        newHPValue = myObjHealth.health;
    }



    private void Update()
    {


        if (newHPValue > myObjHealth.health)
        {
            Debug.Log("HIT TEST");
            TriggerHitEffects();

            newHPValue = myObjHealth.health;
        }

            
        
    }

    void TriggerHitEffects()
    {
        
        if (myVlambeer != null) myVlambeer.ShakeScreen(1);

        //    if (myFlashImage != null)

        if (myHitEffect != null) Instantiate(myHitEffect,transform.position,Quaternion.identity);

        if (myHitAudio != null) mySource.PlayOneShot(myHitAudio);

    }



}
