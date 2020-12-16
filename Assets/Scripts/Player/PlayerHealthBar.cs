using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    GameObject player;
    HealthSys playerHealth;
    public float maxHealth;
    public float currentHealth;

    Image myImage;
    private float height;
    private float y;
    public float offset;


    public float baseWidth;
    public float basePos;
    public float width;
    public float pos;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HealthSys>();
        maxHealth = playerHealth.maxHealth;

        myImage = GetComponent<Image>();
        height = myImage.rectTransform.sizeDelta.y;
        y = myImage.rectTransform.anchoredPosition.y;
        baseWidth = myImage.rectTransform.sizeDelta.x;
        basePos = myImage.rectTransform.anchoredPosition.x;
    }

    private void Update()
    {
        CheckHealth();
        DisplayBar();
    }

    void CheckHealth()
    {
        currentHealth = playerHealth.health;
    }

    void DisplayBar()
    {
        //calcualte size and pos
        width = (currentHealth / maxHealth) * baseWidth;
        pos = basePos + (width / 2) - offset;

        //update
        myImage.rectTransform.sizeDelta = new Vector2(width,height);
        myImage.rectTransform.anchoredPosition = new Vector2(pos, y);
    }
}