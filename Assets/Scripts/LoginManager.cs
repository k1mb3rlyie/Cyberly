using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoginManager : MonoBehaviour
{
    readonly static string SERVER_URL = "http://localhost:80/CyberlyBackend/Backend/";

    public IEnumerator UserLogin(string emailOrUsername, string password)
    {
        string LOGIN_USER_URL = $"{SERVER_URL}/login.php";

        var parameters = new Dictionary<string, string>
        {
            {"login_identifier", emailOrUsername},
            { "password", password }
        };

        foreach (var param in parameters)
        {
            Debug.Log($"{param.Key}: {param.Value}");
        }

        // Log the complete URL request
        Debug.Log($"Sending POST request to: {LOGIN_USER_URL}");

        yield return StartCoroutine(SendPostRequest(LOGIN_USER_URL, parameters));
    }

    private IEnumerator SendPostRequest(string url, Dictionary<string, string> parameters)
    {
        using (UnityWebRequest req = UnityWebRequest.Post(url, parameters))
        {
            req.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return req.SendWebRequest(); 

            if (req.result != UnityWebRequest.Result.Success || HasErrorMessage(req.downloadHandler.text))
            {
                Debug.LogError($"Request Failed: {req.error}");
                Debug.LogError($"Response: {req.downloadHandler.text}");
            }
            else
            {
                Debug.Log("Request success! Response: " + req.downloadHandler.text);
            }
        }
    }

    private static bool HasErrorMessage(string msg)
    {
        // Custom error message checking logic
        return msg.Contains("error") || msg.Contains("fail");
    }
}
