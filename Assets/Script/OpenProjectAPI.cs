using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class OpenProjectAPI : MonoBehaviour
{
    // Start is called before the first frame update
    private string gitHubJsonURL  = "https://github.com/FelixLui116/ProjectAPI_200/blob/main/ProjectAPI_200.json";
    
    private string gameName = "SaveTheWorld";  //SaveTheWorld  BallFight
    private string gameAPI_value;
    
    void Start()
    {
        StartCoroutine(GetGitHubJSON());
    }

    IEnumerator GetGitHubJSON()
    {
        UnityWebRequest www = UnityWebRequest.Get(gitHubJsonURL);
        yield return www.SendWebRequest();
        try
        {
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to retrieve GitHub JSON: " + www.error);
            }
            else
            {
                // Successfully retrieved JSON data
                string jsonText = www.downloadHandler.text;
                Debug.Log("GitHub JSON Data: " + jsonText);

                // Parse the JSON data
                JSONData jsonData = JsonUtility.FromJson<JSONData>(jsonText);

                // // Extract "BallFight" value
                // string ballFightLine = jsonData.payload.blob.rawLines[1].Trim();
                // string ballFightValue = ballFightLine.Split(':')[1].Trim(new char[] { ' ', '"', '\t' });
                // Debug.Log("GitHub BallFight Value: " + ballFightValue);



                string[] gameList = jsonData.payload.blob.rawLines;
                
                // string ballFightValue = jsonData.payload.blob.rawLines[1].Trim(); // This gets the third line of rawLines array
                for (int i = 0; i < gameList.Length; i++)
                {
                    
                    Debug.Log("GitHub BallFight Value: " + gameList[i]);
                    if (gameList[i].Contains(gameName)) // find game name and extract value
                    {
                        // // further parse the line to get the value
                        // int startIndex = gameList[i].IndexOf('"') + 1;
                        // int endIndex = gameList[i].LastIndexOf('"');
                        // string value = gameList[i].Substring(startIndex, endIndex - startIndex);
                        
                        // Debug.Log($"gameList: {gameList}  value: {value}"); // log gameList: System.String[]  value: BallFight": "200
                        // // gameAPI_value = value;
                        // break; // exit for loop

                        string[] parts = gameList[i].Split(':');
                        // Extract the name and remove any extra whitespace and quotes
                        string extractedName = parts[0].Trim('"', ' ', '\t', '\n', '\r');

                        // Extract the value and remove any extra whitespace and quotes
                        string extractedValue = parts[1].Trim('"', ' ', '\t', '\n', '\r');

                        Debug.Log($"Extracted Game Name: {extractedName}  Value: {extractedValue}");
                        // You can assign the extracted values to variables here if needed
                        gameAPI_value = extractedValue;
                        break; // Exit for loop
                    }
                }

                if(gameAPI_value == "200"){
                    Debug.Log("Game API is 200");
                }
                else{
                    Debug.Log("Game API is not 200");
                    PauseGame();
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error: " + e.Message);
            PauseGame();
        }
    }

    [System.Serializable]
    private class JSONData
    {
        public PayloadData payload;
    }

    [System.Serializable]
    private class PayloadData
    {
        public BlobData blob;
    }

    [System.Serializable]
    private class BlobData
    {
        public string[] rawLines;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void PauseGame()
    {
        Time.timeScale = 0.0f; // pause game
    }

}
