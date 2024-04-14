using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public void HazardFound() {
        Debug.Log("Found me!");
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}
