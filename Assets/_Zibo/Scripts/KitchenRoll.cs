using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KitchenRoll : MonoBehaviour
{
    public GameObject newTowelPiece;

    private void Start()
    {
        DestroyAllTowels();
    }

    public void MakeTowel() {
        Instantiate(newTowelPiece, transform);
    }

    public void DestroyAllTowels()
    {
        KitchenTowel[] towels = FindObjectsByType<KitchenTowel>(FindObjectsSortMode.None);

        foreach(var towel in towels)
        {
            Destroy(towel.gameObject);
        }
        MakeTowel();
    }
}
