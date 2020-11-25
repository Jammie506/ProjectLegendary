using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float timer = 5f;
    // Update is called once per frame
    void FixedUpdate()
    {

        timer -= 1 * Time.deltaTime;

        if (timer < 0)
        Destroy(gameObject);

    }
}
