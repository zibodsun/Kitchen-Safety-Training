using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class TrainingManager : MonoBehaviour
{
    public bool knifeTraining, cleaningTraining, storageTraining;
    public AudioSource taskCompleteSound;
    public StateMachine flow;

    private void Awake()
    {
        flow = FindObjectOfType<StateMachine>();
    }

    private void Update()
    {
        if (knifeTraining && cleaningTraining && storageTraining){
            flow.TriggerUnityEvent("TrainingComplete");
        }
    }

    public void CompleteKnifeTraining() 
    { 
        knifeTraining = true;
        taskCompleteSound.Play();
    }

    public void CompleteCleaningTraining()
    {
        cleaningTraining = true;
        taskCompleteSound.Play();
    }

    public void CompleteStorageTraining()
    {
        storageTraining = true;
        taskCompleteSound.Play();
    }
}
