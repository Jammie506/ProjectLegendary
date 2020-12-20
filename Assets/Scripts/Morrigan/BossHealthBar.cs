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
    public float offset;

    public float baseWidth;
    public float basePos;
    public float width;
    public float pos;

    private void Awake()
    {
        boss = GameObject.Find("BossUnit");
        bossHealth = boss.GetComponent<HealthSys>();
        maxHealth = bossHealth.maxHealth;

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
        if(bossHealth != null)
        {
            currentHealth = bossHealth.health;
        }
    }

    void DisplayBar()
    {
        //calcualte size
        width = (currentHealth / maxHealth) * baseWidth;
        pos = basePos + (width / 2) - offset;

        //update
        myImage.rectTransform.sizeDelta = new Vector2(width, height);
        myImage.rectTransform.anchoredPosition = new Vector2(pos, y);
    }
}