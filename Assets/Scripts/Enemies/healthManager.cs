using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    public float currentHealth;
    public float maxHeallth;

    public GameObject gM;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            
            gM.GetComponent<gameManager>().GameOver();
        }
    }
}
