using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HulkChargeUI : MonoBehaviour
{
    PlayerHulkMode hulk;
    Image myImage;
    Animator anim;

    float defaultSize;
    float maxCharge;

    bool animate;

    private void Start()
    {
        hulk = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHulkMode>();
        myImage = GetComponent<Image>();
        anim = GetComponent<Animator>();
        defaultSize = myImage.rectTransform.sizeDelta.x;
        maxCharge = hulk.maxCharge;
    }

    private void Update()
    {
        DisplayCharge();
        AnimateCharge();
    }

    void DisplayCharge()
    {
        int charge = hulk.hulkCharge;
        float size = (charge / maxCharge) * defaultSize;

        myImage.rectTransform.sizeDelta = new Vector2(size, size);

        if(charge >= maxCharge)
        {
            animate = true;
        }
        else
        {
            animate = false;
        }
    }

    void AnimateCharge()
    {
        if (animate)
        {
            anim.SetBool("Full", true);
        }
        else
        {
            anim.SetBool("Full", false);
        }
    }
}