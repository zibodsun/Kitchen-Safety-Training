using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KitchenRoll : MonoBehaviour
{
    public KitchenTowel newTowelPiece;      // Kitchen towel prefab

    XRSimpleInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(MakeTowel);
    }
    
    public void MakeTowel(SelectEnterEventArgs args) {
        Transform _hand = args.interactorObject.transform;
        KitchenTowel _towel = Instantiate(newTowelPiece, _hand.position, Quaternion.identity);
        _towel.hand = _hand;
        _towel.inHand = true;
        _towel.rollInteractable = interactable;
    }
}
