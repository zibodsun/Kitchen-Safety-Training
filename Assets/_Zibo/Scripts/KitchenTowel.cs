using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KitchenTowel : MonoBehaviour
{
    public Material towelMaterial;
    public Material invisibleMaterial;

    XRGrabInteractable interactable;
    Renderer rend;
    KitchenRoll roll;
    Rigidbody rb;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        rend = GetComponent<Renderer>();
        roll = GetComponentInParent<KitchenRoll>();
        rb = GetComponent<Rigidbody>();

        interactable.firstSelectEntered.AddListener(TowelPick);
        rend.material = invisibleMaterial;
        
    }

    public void TowelPick(SelectEnterEventArgs a) {
        rend.material = towelMaterial;
        roll.MakeTowel();

        interactable.firstSelectEntered.RemoveAllListeners();
    }

}
