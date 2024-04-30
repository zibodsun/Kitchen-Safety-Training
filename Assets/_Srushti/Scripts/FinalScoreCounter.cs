using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoreCounter : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SubmitScenario(int hazScore, int knifeScore, int cleaningScore, int storageScore)
    {
        Debug.Log("");
    }
}
