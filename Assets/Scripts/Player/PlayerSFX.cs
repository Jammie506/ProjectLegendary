using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AudioClip swipe, stab, dodge, hit;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySwipe()
    {
        source.PlayOneShot(swipe);
    }

    public void PlayStab()
    {
        source.PlayOneShot(stab);
    }

    public void PlayDodge()
    {
        source.PlayOneShot(dodge);
    }

    public void PlayHit()
    {
        source.PlayOneShot(hit);
    }
}