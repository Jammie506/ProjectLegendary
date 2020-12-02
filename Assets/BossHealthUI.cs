using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    HealthSys bossHealth;
    Text hp;

    private void Start()
    {
        bossHealth = GameObject.Find("BossUnit").GetComponent<HealthSys>();
        hp = GetComponent<Text>();
        Debug.Log(hp);
    }

    private void Update()
    {
        if(bossHealth != null)
        {
            hp.text = "Boss Health: " + bossHealth.health;
        }
    }
}