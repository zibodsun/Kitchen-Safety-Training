using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Respawns objects when they fall out of bounds
 */
public class ResetObjectOOB : MonoBehaviour
{
    Vector3 spawnPosition;
    Rigidbody rb;

    private void Awake()
    {
        spawnPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, spawnPosition) > 20f)
        {
            if(rb != null) { 
                rb.useGravity = false;
                rb.isKinematic = true;
            }

            transform.position = spawnPosition;
            StartCoroutine(ResetObjectPhys());
        }
    }

    IEnumerator ResetObjectPhys()
    {
        yield return new WaitForSeconds(1);
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
