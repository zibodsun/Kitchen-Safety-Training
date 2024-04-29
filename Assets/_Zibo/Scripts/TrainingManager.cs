using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class TrainingManager : MonoBehaviour
{
    public bool knifeTraining, cleaningTraining, storageTraining;
    public AudioSource taskCompleteSound;
    public StateMachine flow;

    [Header("UI elements")]
    public GameObject c;
    public GameObject k;
    public GameObject fs;

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
        if (knifeTraining != false) { return; }
        knifeTraining = true;
        taskCompleteSound.Play();
        k.SetActive(true);
    }

    public void CompleteCleaningTraining()
    {
        if (cleaningTraining != false) { return; }
        cleaningTraining = true;
        taskCompleteSound.Play();
        c.SetActive(true);
    }

    public void CompleteStorageTraining()
    {
        if (storageTraining != false) { return; }
        storageTraining = true;
        taskCompleteSound.Play();
        fs.SetActive(true);
    }
}
