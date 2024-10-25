using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AnswerSubmission : MonoBehaviour
{
    private string phpEndpoint = "http://localhost:80/CyberlyBackend/Backend/essayupdate.php";  // Replace with your PHP URL

    // Call this function when you're ready to submit answers and questions
    public void SubmitAnswers(string[] questions, string[] answers)
    {
        StartCoroutine(SendAnswersToBackend(questions, answers));
    }

    IEnumerator SendAnswersToBackend(string[] questions, string[] answers)
    {
        // Prepare questions and answers as a JSON object
        string jsonData = "{ \"questions\": [";
        for (int i = 0; i < questions.Length; i++)
        {
            jsonData += "\"" + questions[i] + "\"";
            if (i < questions.Length - 1) jsonData += ", ";  // Add commas between questions
        }
        jsonData += "], \"answers\": [";
        for (int i = 0; i < answers.Length; i++)
        {
            jsonData += "\"" + answers[i] + "\"";
            if (i < answers.Length - 1) jsonData += ", ";  // Add commas between answers
        }
        jsonData += "] }";

        // Create a new UnityWebRequest for a POST request
        UnityWebRequest www = new UnityWebRequest(phpEndpoint, "POST");

        // Convert jsonData to bytes and assign it to the upload handler
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        www.uploadHandler = new UploadHandlerRaw(jsonToSend);

        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error: " + www.error);
        }
        else
        {
            // Output the response from the backend for testing
            Debug.Log("Response: " + www.downloadHandler.text);
        }
    }
}
//this script was largely written by ChatGPT3