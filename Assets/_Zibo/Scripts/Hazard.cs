using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public Color acceptColor;
    public AudioSource correctSound;
    public AudioSource HazardSpottedSound;
    public bool OB;
    public bool found;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void HazardFound() {
        Debug.Log("Found me!");
        GetComponent<Renderer>().material.color = acceptColor;

        if (!OB)
        {
            found = true;
            correctSound.Play();
            HazardSpottedSound.Play();
            anim.Play("HazardIndicatorFadeOut");
        }
    }
}