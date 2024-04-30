using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RecordTestScores : MonoBehaviour
{
    [Header("Scene-sensitive Evaluation Specs")]
    public int knifeReplaceCount = 2;
    public int stainsToCleanCount = 3;
    public int correctlyStoredContainers = 0;

    [Header("Hazard Indicators")]
    public List<Hazard> indicators;

    [Header("Knife Task Components")]
    public List<ReceiveKnife> hooks;

    [Header("Cleaning Task Components")]
    public List<DryableElement> elements;

    [Header("Storage Task Components")]
    public StorageArea[] colliders = new StorageArea[3];

    [Header("Private Counters (Updates on Submit)")]
    [SerializeField] int _hazCount;     // Hazards Found
    [SerializeField] int _knfCount;     // Hazards Fixed
    [SerializeField] int _clnCount;
    [SerializeField] int _storCount;

    [Header("Global Score Tracking")]
    [SerializeField] FinalScoreCounter _scoreCounter;

    private void Awake()
    {
        _scoreCounter = FindAnyObjectByType<FinalScoreCounter>();    
    }

    public void SubmitScores() {
        _hazCount = 0;
        _knfCount = 0;
        _clnCount = 0;
        _storCount = 0;

        foreach (Hazard i in indicators)
        {
            if (i.found) { _hazCount++; }
        }

        foreach (ReceiveKnife h in hooks) {
            if (h.trig) { _knfCount++; }
        }

        foreach (DryableElement d in elements) { 
            if (d.clean) { _clnCount++; }
        }

        foreach (StorageArea s in colliders)
        {
            _storCount = _storCount + s.GetStoredAmount();
        }

        _scoreCounter.SubmitScenario(_hazCount, _knfCount, _clnCount, _storCount);
    }
}
