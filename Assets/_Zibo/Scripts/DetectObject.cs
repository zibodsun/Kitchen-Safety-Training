using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    public string objTag = "onboardingBall";

    RaycastHit _hit;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.up * .05f, Color.yellow);

        if (Physics.Raycast(transform.position, transform.up, out _hit, .05f)){
            _hit.collider.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
