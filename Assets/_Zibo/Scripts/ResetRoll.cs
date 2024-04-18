using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRoll : MonoBehaviour
{
    public KitchenRoll roll;
    bool _activeLast;

    public void DestroyAllTowels()
    {
        KitchenTowel[] towels = FindObjectsByType<KitchenTowel>(FindObjectsSortMode.None);

        foreach (var towel in towels)
        {
            Destroy(towel.gameObject);
        }
    }

    private void Update()
    {
        /*
         * Resets all the kitchen towels if the object is disabled in hierarchy
         */
        if (roll.gameObject.activeInHierarchy != _activeLast)
        {  // Object has just been turned off
            DestroyAllTowels();
        }
        _activeLast = roll.gameObject.activeInHierarchy;
    }
}
