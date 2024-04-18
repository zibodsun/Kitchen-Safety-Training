using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KitchenRoll : MonoBehaviour
{
    public KitchenTowel newTowelPiece;      // Kitchen towel prefab

    XRSimpleInteractable interactable;
    bool _activeLast;

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

    public void DestroyAllTowels()
    {
        KitchenTowel[] towels = FindObjectsByType<KitchenTowel>(FindObjectsSortMode.None);

        foreach(var towel in towels)
        {
            Destroy(towel.gameObject);
        }
    }

    private void Update()
    {
        /*
         * Resets all the kitchen towels if the object is disabled in hierarchy
         */
        if (gameObject.activeInHierarchy && gameObject.activeInHierarchy != _activeLast) {  // Object has just been turned on
            DestroyAllTowels();
        }

        _activeLast = gameObject.activeInHierarchy;
    }
}
