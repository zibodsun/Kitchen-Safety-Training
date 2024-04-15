using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    RaycastHit hit;
    float timer;
    public float holdTime = 1.5f;
    public Transform direction;

    Vector3 _forward;
    float _maxDistance;

    private void Start()
    {
        Vector3 _temp = direction.position - transform.position;
        _forward = _temp.normalized;
        _maxDistance = Vector3.Distance(transform.position, direction.position);
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8;
        Debug.DrawRay(transform.position, _forward * _maxDistance, Color.yellow);

        if (Physics.Raycast(transform.position, _forward, out hit, _maxDistance, layerMask))
        {
            

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
