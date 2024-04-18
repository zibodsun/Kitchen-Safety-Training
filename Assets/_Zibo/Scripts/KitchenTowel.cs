using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KitchenTowel : MonoBehaviour
{
    public bool inHand;
    public Transform hand;
    public XRSimpleInteractable rollInteractable;

    Rigidbody rb;
    XRGrabInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rollInteractable.isSelected && inHand)
        {
            transform.position = hand.position;
            transform.rotation = hand.rotation;
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        else {
            inHand = false;
            interactable.enabled = true;
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
}
