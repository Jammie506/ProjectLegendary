using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VlambeerOnCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        getPlayer = GameObject.Find("Player");

        getVlambeer = getPlayer.GetComponent<Vlambeer>();

        getVlambeer.ShakeScreen(1);

    }

    GameObject getPlayer;
    Vlambeer getVlambeer;

    
}
