using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnTime : MonoBehaviour
{
    public float seconds;
    private float timer;
    public bool spawned;

    GameObject boss;

    private void Start()
    {
        timer = seconds;
        boss = GameObject.Find("BossUnit");
        boss.SetActive(false);
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0 && !spawned)
        {
            spawned = true;
            boss.SetActive(true);
        }
    }
}