using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

/*
 *  Sends data to AirTable
 */
public class AirtableManager : MonoBehaviour
{
    [Header("Scripts")]

    [Header("Airtable Elements")]
    // Airtable API endpoint and authentication details
    public string airtableEndpoint = "https://api.airtable.com/v0/";
    public string accessToken = "YOUR_ACCESS_TOKEN";
    public string baseId = "YOUR_BASE_ID";
    public string tableName = "YOUR_TABLE_NAME";
    private string dataToParse;

    [Header("Data For Airtable")]
    // Data fields for recording information
    public string dateTime;
    public string haz_1 = "0";
    public string haz_2 = "0";
    public string haz_3 = "0";
    public string cln_1 = "0";
    public string cln_2 = "0";
    public string cln_3 = "0";
    public string knf_1 = "0";
    public string knf_2 = "0";
    public string knf_3 = "0";
    public string str_2 = "0";
    public string str_3 = "0";

    [Header("Data From Airtable")]
    // Data fields for retrieving information from Airtable
    public string dataToLoad;
    public string lastRecordID;
    public string playerNameFromAirtable;
    public string volumeFromAirtable;
    public string coinsFromAirtable;
    public string timePlayedFromAirtable;
    public string healthFromAirtable;
    public string scoreFromAirtable;

    // Method to create a new record in Airtable
    public void CreateRecord()
    {
        // Reset dataToLoad if it is not null
        if (dataToLoad != null)
        {
            dataToLoad = null;
        }

        // Get the current date and time
        dateTime = DateTime.Now.ToString("dd.MM.yyyy HH.mm");

        // Create the URL for the API request
        string url = airtableEndpoint + baseId + "/" + tableName;

        // Create JSON data for the API request
        string jsonFields = "{\"fields\": {" +
                                    "\"DateTime\":\"" + dateTime + "\", " +
                                    "\"haz_1\":\"" + haz_1 + "\", " +
                                    "\"haz_2\":\"" + haz_2 + "\", " +
                                    "\"haz_3\":\"" + haz_3 + "\", " +
                                    "\"cln_1\":\"" + cln_1 + "\", " +
                                    "\"cln_2\":\"" + cln_2 + "\", " +
                                    "\"cln_3\":\"" + cln_3 + "\", " +
                                    "\"knf_1\":\"" + knf_1 + "\", " +
                                    "\"knf_2\":\"" + knf_2 + "\", " +
                                    "\"knf_3\":\"" + knf_3 + "\", " +
                                    "\"str_2\":\"" + str_2 + "\", " +
                                    "\"str_3\":\"" + str_3 + "\"" +
                                    "}}";

        // Start the coroutine to send the API request
        StartCoroutine(SendRequest(url, "POST", response =>
        {
            // Log the response from the API
            Debug.Log("Record created: " + response);

            // Store the response for parsing
            dataToParse = response;

            // Parse the JSON response
            JSONParse();
        }, jsonFields));
    }

    // Coroutine to make API requests
    private IEnumerator SendRequest(string url, string method, Action<string> callback, string jsonData = "")
    {
        // Create a HTTP web request
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = method;
        request.ContentType = "application/json";
        request.Headers["Authorization"] = "Bearer " + accessToken;

        // Include JSON data in the request if provided
        if (!string.IsNullOrEmpty(jsonData))
        {
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonData);
            }
        }

        // Get the response from the API
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string jsonResponse = reader.ReadToEnd();
                // Invoke the callback with the response
                if (callback != null)
                {
                    callback(jsonResponse);
                }
            }
        }

        // Yield to the next frame
        yield return null;
    }

    // Method to retrieve a specific record from Airtable
    public void GetRecordValue(string recordID)
    {
        // Call the RetrieveRecord method with provided record ID and table name
        RetrieveRecord(recordID, tableName);
    }

    // Method to retrieve a record from Airtable based on record ID
    public void RetrieveRecord(string recordId, string readTableName)
    {
        // Create the URL for the API request
        string url = airtableEndpoint + baseId + "/" + readTableName + "/" + recordId;

        // Start the coroutine to send the API request
        StartCoroutine(SendRequest(url, "GET", response =>
        {
            // Parse the JSON response
            var responseObject = JsonUtility.FromJson<Dictionary<string, object>>(response);

            // Store the response for parsing
            dataToParse = response;

            // Parse the JSON response
            JSONParse();
        }));
    }

    // Method to parse the JSON response from Airtable
    public void JSONParse()
    {
        // Get the JSON source data
        string source = dataToParse;

        // Parse the JSON using Newtonsoft.Json
        dynamic data = JObject.Parse(source);

        // Extract the record ID from the parsed JSON
        lastRecordID = data.id;

        // Log the last record ID
        Debug.Log("Last RecordID was: " + data.id);

        // Extract and display data based on the specified dataToLoad value
        if (dataToLoad == "PlayerName")
        {
            //playerNameFromAirtable = data.fields.PlayerName;           
            Debug.Log("From Airtable: Player Name: " + playerNameFromAirtable);
        }

        if (dataToLoad == "Volume")
        {
            //volumeFromAirtable = data.fields.Volume;
            Debug.Log("From Airtable: Volume Data: " + volumeFromAirtable);
        }

        if (dataToLoad == "PlayerData")
        {
            playerNameFromAirtable = data.fields.PlayerName;
            volumeFromAirtable = data.fields.Volume;
            Debug.Log("From Airtable: Player Name: " + playerNameFromAirtable + ". Volume Data: " + volumeFromAirtable);
        }

        if (dataToLoad == "GameData")
        {
            coinsFromAirtable = data.fields.Coins;
            timePlayedFromAirtable = data.fields.TimePlayed;
            healthFromAirtable = data.fields.Health;
            scoreFromAirtable = data.fields.Score;


            Debug.Log("From Airtable: Game Data: Coins: " + coinsFromAirtable + " Time Played: " + timePlayedFromAirtable +
                      " Health Data: " + healthFromAirtable + " Score Data: " + scoreFromAirtable);
        }
    }
}
