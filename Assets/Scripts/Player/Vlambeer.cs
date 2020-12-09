using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vlambeer : MonoBehaviour
{   // Its Screenshake
    

    [SerializeField]
    GameObject myCamPos;
    Vector2 getOriginPos;
    private float xPos = 0, yPos = 0;
    private float randX, randY;

    [Header("Settings")]
    public float shakeStrength = 1f;
    public float fallOff = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P)) ShakeScreen(shakeStrength);      // For Testing Purposes

        randX = Random.Range(-xPos,xPos);
        randY = Random.Range(-yPos,yPos);


        myCamPos.transform.Translate(new Vector2(randX,randY));

        if (xPos > 0 || yPos > 0)
        {
            xPos -= fallOff * Time.deltaTime;
            yPos -= fallOff * Time.deltaTime;

            if (xPos >= 0.1f || yPos >= 0.1f)
            {

                Mathf.Round(xPos);
                Mathf.Round(yPos);
            }

        }
        else if (xPos < 0 || yPos < 0)
        {
            xPos = 0;
            yPos = 0;
        }

    }

    public void ShakeScreen(float intensity)        // To be triggered from other scripts
    {

        xPos = intensity;
        yPos = intensity;
        Debug.Log("SCREENSHAKE");
    }

}
