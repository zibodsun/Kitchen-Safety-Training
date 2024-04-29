using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageArea : MonoBehaviour
{
    public FoodContainer.Type foodType;

    [SerializeField] int _storedAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<FoodContainer>(out FoodContainer o))
        {
            if(o.foodType == foodType)
            {
                _storedAmount++;
            }     
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<FoodContainer>(out FoodContainer o))
        {
            if (o.foodType == foodType)
            {
                _storedAmount--;
            }
        }
    }

    public void ResetStoredAmount() {
        _storedAmount = 0;
    }

    public int GetStoredAmount() {
        return _storedAmount;
    }
}
