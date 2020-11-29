using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector2 playerPos;
    private Vector2 myPos;
    private Vector2 direction;
    private float speed;
    private float dist;
    public float followDistance;

    private void Start()
    {
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().speed;
    }

    private void Update()
    {
        PlayerCam();
    }

    void PlayerCam()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        myPos = transform.position;
        direction = playerPos - myPos;
        dist = Vector2.Distance(playerPos, myPos);

        if(dist >= followDistance)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
