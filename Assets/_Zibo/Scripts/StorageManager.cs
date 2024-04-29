using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class StorageManager : MonoBehaviour
{
    public List<FoodContainer> containers;
    public StorageArea[] storageColliders = new StorageArea[3];
    public bool training;

    StateMachine _flow;
    TrainingManager _trainingManager;

    private void Awake()
    {
        _flow = FindObjectOfType<StateMachine>();
        _trainingManager = FindObjectOfType<TrainingManager>();
    }

    private void Update()
    {
        if (training) {
            foreach (StorageArea s in storageColliders) {
                if (s.GetStoredAmount() != 1) {
                    return;
                }
            }
            _flow.TriggerUnityEvent("StorageCompleted");
            _trainingManager.CompleteStorageTraining();
        }
    }

    public void ResetStorage() {
        foreach (StorageArea s in storageColliders)
        {
            s.GetComponent<Collider>().enabled = true;
            s.ResetStoredAmount();
        }

        foreach (FoodContainer c in containers)
        {
            c.Respawn();    
        }
    }

    public void DisableColliders() {
        foreach(StorageArea s in storageColliders)
        {
            s.GetComponent<Collider>().enabled = false;
        }
    }
}
