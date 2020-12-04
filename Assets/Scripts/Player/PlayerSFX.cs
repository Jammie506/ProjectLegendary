using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AudioClip attack, hit, dodge, getHit, knockBack;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayAttack()
    {
        source.PlayOneShot(attack);
    }

    public void PlayHit()
    {
        source.PlayOneShot(hit);
    }

    public void PlayDodge()
    {
        source.PlayOneShot(dodge);
    }

    public void PlayGetHit()
    {
        source.PlayOneShot(getHit);
    }

    public void PlayKnockBack()
    {
        source.PlayOneShot(knockBack);
    }
}