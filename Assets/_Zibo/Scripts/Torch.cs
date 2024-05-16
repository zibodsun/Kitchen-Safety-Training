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
    Light _spotLight;
    Color _spotLightColour;
    bool col_switch;

    private void Start()
    {
        _maxDistance = Vector3.Distance(transform.position, direction.position);
        _spotLight = transform.GetComponentInChildren<Light>();
        _spotLightColour = _spotLight.color;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _temp = direction.position - transform.position;
        _forward = _temp.normalized;

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
                col_switch = true;
            }
        }
        else {
            timer = 0f;
        }

        if (col_switch) {
            StartCoroutine(FlashlightChangeColour());
            col_switch = false;
        }
    }

    IEnumerator FlashlightChangeColour() {
        _spotLight.color = hit.collider.GetComponent<Renderer>().material.color;
        yield return new WaitForSeconds(holdTime);
        _spotLight.color = _spotLightColour;
    }
}
