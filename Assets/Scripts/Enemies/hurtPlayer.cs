using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hurtPlayer : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            /*other.gameObject.SetActive(false);
            SceneManager.LoadScene("GameOve");*/

            other.gameObject.GetComponent<healthManager>().HurtPlayer(10);
        }
    }
}
