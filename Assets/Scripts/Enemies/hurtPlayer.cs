using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hurtPlayer : MonoBehaviour
{
    public float timer = 5;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player" && timer >= 5)
        {
            other.gameObject.GetComponent<healthManager>().HurtPlayer(10);
            timer = 0;
        }
    }
}
