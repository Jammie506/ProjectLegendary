using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float rotateSpeed = 180f;
    public float rotateDelay = 0f;


    // Update is called once per frame
    void FixedUpdate()
    {

        if (rotateDelay <= 0)
        {
            transform.rotation = transform.rotation * Quaternion.Euler(0, 0, rotateSpeed * Time.deltaTime);
        }
        else
        {
            rotateDelay -= 1 * Time.deltaTime;
        }


    }
}
