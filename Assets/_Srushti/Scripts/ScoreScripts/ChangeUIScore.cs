using System;
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
    
    public TMP_Text[] scoreValue;
    public string[] scoreTexts = new string[12];


    private void Awake()
    {
        _endScoreCounter = FindAnyObjectByType<FinalScoreCounter>();    
    }
    public void Start()
    {
        if(_endScoreCounter == null)
        {
            Debug.LogError("End Score Counter is null");
        }
        else
        {
            Debug.Log("End Score Counter is not null");
        }

        DisplayScores();
    }
    public void DisplayScores()
    {
        Debug.Log("Displaying Scores");
        Debug.Log("end game score count array is: ---------------------------------------------");

        // Display the array in the debug log
        Debug.Log("Array Values:");
        
        for (int i = 0; i < 3; i++)
        {
            string sceneString = "Scene " + _endScoreCounter.endScores[i, 0] + ":";
            for (int j = 1; j < 5; j++)
            {
                sceneString += " " + _endScoreCounter.endScores[i, j]; // Concatenate scores with scene number
            }
            Debug.Log(sceneString);
        }

        //----------------------------------------------------------
        // Initialize scoreTexts array
        
        int index = 0;
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            for (int j = 1; j < 5; j++)
            {
                // Convert the integer score to string
                string scoreString = _endScoreCounter.endScores[i, j].ToString(); 
                // ---- getting ERROR here: "indexoutofrangeexception: index was outside the bounds of the array." ----

                // Assign the score to the corresponding TextMeshProUGUI element
                scoreTexts[index] = scoreString;
                
                index++;
            }
        }

        // Display the scoreTexts array
        Debug.Log("Score Texts Array ------------:");
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            Debug.Log(scoreTexts[i]);
        }

        //assign the score values to the UI elements
        for (int i = 0; i < scoreValue.Length; i++)
        {
            scoreValue[i].text = scoreTexts[i];
        }

    }
}
