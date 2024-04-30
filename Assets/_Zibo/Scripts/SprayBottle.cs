using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayBottle : MonoBehaviour
{
    public Transform nozzle;

    RaycastHit hit;

    public void Spray() {
        Debug.DrawRay(nozzle.position, nozzle.forward * 5f, Color.yellow);

        if (!Physics.SphereCast(nozzle.position, .001f, nozzle.forward, out hit, .5f)) {
            return;
        }
        Debug.Log("Hit " + hit.collider.gameObject.name);
        DryableElement _dirtySpot;
        hit.collider.TryGetComponent<DryableElement>(out _dirtySpot);

        Debug.Log(_dirtySpot.gameObject.name);
        if (_dirtySpot != null) {
            _dirtySpot.sprayed = true;    
        }
    }
}
