using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoreCounter : MonoBehaviour
{
    public int sceneCount = 0; //to count the number of scenes

    public int[,] endScores = new int[3, 5]; //to store the scores of each scene

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SubmitScenario(int hazScore, int knifeScore, int cleaningScore, int storageScore)
    {
        Debug.Log("Entered the submit score funct");

        while (sceneCount < 3){
            Debug.Log("Entered the while to update scores");

            sceneCount++; //increment the scene count

            int i = 0; //row counter for the endScores array

            //to make sure the scores are filled in the correct row
            if (sceneCount == 1)
                i = 0;
            if (sceneCount == 2)
                i = 1;
            if (sceneCount == 3)
                i = 2;

            endScores[i, 0] = sceneCount;
            Debug.Log(" scene no at position :" +i+","+ "0 is " + endScores[i, 0]);
                
            for (int j = 1; j < 5; j++)
            {
                if(j == 1)
                {
                    endScores[i, j] = hazScore;
                    Debug.Log(" haz count for scene "+ endScores[i, 0] + ", at position :" + i + "," + j + " is " + endScores[i, j]);
                }
                if (j == 2)
                {
                    endScores[i, j] = knifeScore;
                    Debug.Log(" knife count for scene " + endScores[i, 0] + ", at position :" + i + "," + j + " is " + endScores[i, j]);
                }
                if (j == 3)
                {
                    endScores[i, j] = cleaningScore;
                    Debug.Log(" cleaning count for scene " + endScores[i, 0] + ", at position :" + i + "," + j + " is " + endScores[i, j]);
                }
                if (j == 4)
                {
                    endScores[i, j] = storageScore;
                    Debug.Log(" storage count for scene " + endScores[i, 0] + ", at position :" + i + "," + j + " is " + endScores[i, j]);
                }
            }
            
            Debug.Log("end of filling scores in row:" + i + " which is scene number: " + sceneCount);

            //Debug.Log("end game score count array is: ---------------------------------------------" );

            //for (int i = 0; i < endScores.GetLength(0); i++)
            //{
            //    for (int j = 0; j < endScores.GetLength(1); j++)
            //    {
            //        Debug.Log("End score array values at: " +i+ "," +j+ "are: " + endScores[i, j]);
            //    }
            //}

            break;
        }
            
    }
}
