using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayBottle : MonoBehaviour
{
    public Transform nozzle;
    public bool spray;
    public LayerMask layerMask;

    RaycastHit hit;
    float sphereCastRadius = 0.1f;
    float range = 0.5f;

    private void Update()
    {
        if (spray) { Spray(); }
    }
    public void Spray() {
        Debug.DrawRay(nozzle.position, nozzle.forward * 5f, Color.yellow);

        if (!Physics.SphereCast(nozzle.position, sphereCastRadius, nozzle.forward, out hit, range, layerMask)) {
            return;
        }
        Debug.Log("Hit " + hit.collider.gameObject.name);

        DryableElement _dirtySpot;
        if( hit.collider.TryGetComponent<DryableElement>(out _dirtySpot) )
        {
            Debug.Log("hit = " + hit.collider.gameObject.name + " component = " + _dirtySpot.gameObject.name);
            if (_dirtySpot != null)
            {
                _dirtySpot.sprayed = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(nozzle.position, range);

        RaycastHit hit;
        if (Physics.SphereCast(nozzle.position, sphereCastRadius, nozzle.forward * range, out hit, range, layerMask))
        {
            Gizmos.color = Color.green;
            Vector3 sphereCastMidpoint = nozzle.position + (nozzle.forward * hit.distance);
            Gizmos.DrawWireSphere(sphereCastMidpoint, sphereCastRadius);
            Gizmos.DrawSphere(hit.point, 0.1f);
            Debug.DrawLine(nozzle.position, sphereCastMidpoint, Color.green);
        }
        else
        {
            Gizmos.color = Color.red;
            Vector3 sphereCastMidpoint = nozzle.position + (nozzle.forward * (range - sphereCastRadius));
            Gizmos.DrawWireSphere(sphereCastMidpoint, sphereCastRadius);
            Debug.DrawLine(nozzle.position, sphereCastMidpoint, Color.red);
        }
    }
}
