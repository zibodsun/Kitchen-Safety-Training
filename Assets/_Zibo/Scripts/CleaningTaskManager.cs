using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using Unity.Mathematics;

public class CleaningTaskManager : MonoBehaviour
{
    public List<DryableElement> elements;

    [Header("Training variables")]
    public DryableElement element_1;
    public DryableElement element_2;
    public SprayBottle sprayBottle;
    public Transform spawnSprayBottle;

    StateMachine flow;
    TrainingManager trainingManager;

    private void Awake()
    {
        flow = FindObjectOfType<StateMachine>();
        trainingManager = FindObjectOfType<TrainingManager>();
    }

    private void Update()
    {
        if (elements.All(e => e.clean)) {
            flow.TriggerUnityEvent("CleaningCompleted");
            trainingManager.CompleteCleaningTraining();

        }
    }

    public void ResetCleaning()
    {
        element_1.GetComponent<Collider>().enabled = true;
        element_2.GetComponent<Collider>().enabled = true;
        element_1.sprayed = false;
        element_2.sprayed = false;
        element_1.clean = false;
        element_2.clean = false;
        element_1.GetComponent<Animator>().Play("Idle");
        element_2.GetComponent<Animator>().Play("Idle");
        element_1.GetComponent<Animator>().speed = 0f;
        element_2.GetComponent<Animator>().speed = 0f;
        sprayBottle.transform.position = spawnSprayBottle.position;
        sprayBottle.transform.rotation = spawnSprayBottle.rotation;
    }

    public void DisableColliders() {
        element_1.GetComponent<Collider>().enabled = false;
        element_2.GetComponent<Collider>().enabled = false;
    }
}
