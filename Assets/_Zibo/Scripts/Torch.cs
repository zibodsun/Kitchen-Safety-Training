using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    RaycastHit hit;
    float timer;
    public float holdTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (timer < holdTime)
            {
                timer += Time.deltaTime;
            }
            else {
                hit.collider.GetComponent<Hazard>().HazardFound();
            }
        }
        else {
            timer = 0f;
        }
    }
}
