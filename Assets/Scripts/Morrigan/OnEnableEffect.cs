using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableEffect : MonoBehaviour
{
    

    public GameObject myEffect;

    private void OnEnable()
    {
        Instantiate(myEffect,transform.position,Quaternion.identity);
    }

    private void OnDisable()
    {
        Instantiate(myEffect, transform.position, Quaternion.identity);
    }


}
