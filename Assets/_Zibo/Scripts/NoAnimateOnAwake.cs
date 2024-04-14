using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAnimateOnAwake : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Animator>().speed = 0f;
    }
}
