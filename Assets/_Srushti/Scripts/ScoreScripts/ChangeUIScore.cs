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

    [Header("Airtable")]
    public AirtableManager airtableManager;

    private void Awake()
    {
        _endScoreCounter = FindAnyObjectByType<FinalScoreCounter>();
        airtableManager = GetComponent<AirtableManager>();
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
        SendToAirtable();
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
        for (int i = 0; i < _endScoreCounter.endScores.GetLength(0); i++)
        {
            for (int j = 1; j < 5; j++)
            {
                // Convert the integer score to string
                Debug.LogWarning("*___" + i + " " + j + "___*");
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

    public void SendToAirtable() {
        airtableManager.haz_1 = scoreTexts[0];
        airtableManager.knf_1 = scoreTexts[1];
        airtableManager.cln_1 = scoreTexts[2];
        //airtableManager.str_1 = scoreTexts[3];
        airtableManager.haz_2 = scoreTexts[4];
        airtableManager.knf_2 = scoreTexts[5];
        airtableManager.cln_2 = scoreTexts[6];
        airtableManager.str_2 = scoreTexts[7];
        airtableManager.haz_3 = scoreTexts[8];
        airtableManager.knf_3 = scoreTexts[9];
        airtableManager.cln_3 = scoreTexts[10];
        airtableManager.str_3 = scoreTexts[11];

        airtableManager.CreateRecord();
    }
}
