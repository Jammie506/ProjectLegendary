using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralRotate : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed);
    }
}