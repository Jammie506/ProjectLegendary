using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfBullets : MonoBehaviour
{
    
    // This is for testing purposes may or may not be in the game

    void Start()
    {
        theta = radian * Mathf.Rad2Deg;
        Debug.Log(theta);
        int numToLoop = ringNum;

        for (int i = 0; i < numToLoop; i++)
        {

            Instantiate(myObject,myPos = new Vector2(transform.position.x + Mathf.Sin(theta * i) * radius, transform.position.y - Mathf.Cos(theta * i) * radius),Quaternion.identity);

        }

    }

    float theta = 1 * Mathf.Rad2Deg;
    public float radian = 2;
    public float radius = 5;

    public int ringNum = 12;
    Vector2 myPos;
    public GameObject myObject;
    
    void Update()
    {
        
    }
}
