using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ChangeUIScore : MonoBehaviour
{
    [Header("Global Score Tracking")]
    public FinalScoreCounter _endScoreCounter;

    [Header("Project UI Elements")]
    public Image[] scoreImages;
    public TMP_Text[] scoreValue;

    private void Awake()
    {
        _endScoreCounter = FindAnyObjectByType<FinalScoreCounter>();    
    }

    public void DisplayScores()
    {
        Debug.Log("Displaying Scores");
        Debug.Log("end game score count array is: ---------------------------------------------");

        for (int i = 0; i < _endScoreCounter.endScores.GetLength(0); i++)
        {
            for (int j = 0; j < _endScoreCounter.endScores.GetLength(1); j++)
            {
                Debug.Log("End score array values at: " + i + "," + j + "are: " + _endScoreCounter.endScores[i, j]);
            }
        }

        // Display the scores on the UI
        //if ()
        //{
        //    scoreImages[].color = Color.green;
        //}
        //else
        //{
        //    scoreImages[].color = Color.red;
        //}
    }
}
