using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeTrainingManager : MonoBehaviour
{
    public ReceiveKnife hook1;
    public ReceiveKnife hook2;
    public Transform L;
    public Transform R;
    public GameObject knifePrefab;

    StateMachine flow;

    private void Awake()
    {
        flow = FindObjectOfType<StateMachine>();
    }

    private void Update()
    {
        if(hook1.trig && hook2.trig)
        {
            flow.TriggerUnityEvent("KnifeCompleted");
        }
    }
    public void ResetTraining()
    {
        hook1.GetComponent<Collider>().enabled = true;
        hook2.GetComponent<Collider>().enabled = true;
        hook1.trig = false;
        hook2.trig = false;
        hook1.animatedKnife.SetActive(false);
        hook2.animatedKnife.SetActive(false);
        Instantiate(knifePrefab, L.position, L.rotation);
        Instantiate(knifePrefab, R.position, R.rotation);
    }
    public void DisableColliders() {
        hook1.GetComponent<Collider>().enabled = false;
        hook2.GetComponent<Collider>().enabled = false;
    }

    public void ClearKnives() {
        GameObject[] _knives = GameObject.FindGameObjectsWithTag("LooseKnife");

        foreach(GameObject _o in _knives)
        {
            Destroy(_o);
        }
    }
}
