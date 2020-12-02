using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    GameObject player;
    Text hp;
    Text hulkCharge;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hp = GameObject.Find("Player HP Text").GetComponent<Text>();
        hulkCharge = GameObject.Find("Player Hulk Charge Text").GetComponent<Text>();
    }

    private void Update()
    {
        hp.text = "HP: " + player.GetComponent<HealthSys>().health;
        hulkCharge.text = "Charge: " + player.GetComponent<PlayerHulkMode>().hulkCharge;
    }
}