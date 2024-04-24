using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DryableElement : MonoBehaviour
{
    Animator anim;
    public bool sprayed;
    public bool clean;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "sheet")
        {
            anim.speed = 1f;
        }
    }

    public void FinishCleaning()
    {
        if (sprayed) {
            clean = true;
        }
        else {
            Debug.Log("Area has not been sprayed before cleaning");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "sheet")
        {
            anim.speed = 0f;
        }
    }
}
