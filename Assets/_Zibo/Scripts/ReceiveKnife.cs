using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveKnife : MonoBehaviour
{
    public GameObject animatedKnife;
    public bool trig;

    private void Awake()
    {
        animatedKnife = transform.GetChild(0).gameObject;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LooseKnife")
        {
            animatedKnife.SetActive(true);
            trig = true;
            Destroy(other.gameObject);
        }
    }
}
