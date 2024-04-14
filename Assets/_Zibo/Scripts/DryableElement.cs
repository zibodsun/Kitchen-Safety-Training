using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DryableElement : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "sheet")
        {
            anim.speed = 1f;
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
