using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    GameObject boss;
    HealthSys bossHealth;
    public float maxHealth;
    public float currentHealth;

    Image myImage;
    private float height;
    private float y;

    public float baseWidth;
    public float width;


    private void Start()
    {
        boss = GameObject.Find("BossUnit");
        bossHealth = boss.GetComponent<HealthSys>();
        maxHealth = bossHealth.maxHealth;

        myImage = GetComponent<Image>();
        height = myImage.rectTransform.sizeDelta.y;
        y = myImage.rectTransform.anchoredPosition.y;
        baseWidth = myImage.rectTransform.sizeDelta.x;
    }

    private void Update()
    {
        CheckHealth();
        DisplayBar();
    }

    void CheckHealth()
    {
        currentHealth = bossHealth.health;
    }

    void DisplayBar()
    {
        //calcualte size
        width = (currentHealth / maxHealth) * baseWidth;

        //update
        myImage.rectTransform.sizeDelta = new Vector2(width, height);
    }
}