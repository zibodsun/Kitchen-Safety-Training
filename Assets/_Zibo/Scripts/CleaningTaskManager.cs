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

    StateMachine flow;

    private void Awake()
    {
        flow = FindObjectOfType<StateMachine>();
    }

    private void Update()
    {
        if (elements.All(e => e.clean)) {
            flow.TriggerUnityEvent("CleaningCompleted");
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
    }

    public void DisableColliders() {
        element_1.GetComponent<Collider>().enabled = false;
        element_2.GetComponent<Collider>().enabled = false;
    }
}
