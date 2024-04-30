using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoreCounter : MonoBehaviour
{
    private int sceneCount = 0; //to count the number of scenes

    [Header("Final Scores")]
    [SerializeField] int finalHazCount = 0;     
    [SerializeField] int finalKnfCount = 0;     
    [SerializeField] int finalClnCount = 0;
    [SerializeField] int finalStorCount = 0;

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

            finalHazCount += hazScore;
            finalKnfCount += knifeScore;
            finalClnCount += cleaningScore;
            finalStorCount += storageScore;
            Debug.Log("final scores after scene: " + sceneCount + " are as below: ");
            Debug.Log("final Hazard count after scene: " + sceneCount + " is: " + finalHazCount);
            Debug.Log("final knife count after scene: " + sceneCount + " is: " + finalKnfCount);
            Debug.Log("final cleaning count after scene: " + sceneCount + " is: " + finalClnCount);
            Debug.Log("final storage count after scene: " + sceneCount + " is: " + finalStorCount);

        }
        
    }
}
