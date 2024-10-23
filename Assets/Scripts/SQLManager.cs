using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SQLManager : MonoBehaviour
{
    readonly static string SERVER_URL = "http://localhost:80/CyberlyBackend/Backend/";

    public void NewUserReg(string f_name, string l_name, string user_name, string password, string email, DateTime DOB)
    {
        string REGISTER_USER_URL = $"{SERVER_URL}/register.php";

        var parameters = new Dictionary<string, string>
        {
            { "f_name", f_name },
            { "l_name", l_name },
            { "user_name", user_name },
            { "password", password },
            { "email", email },
            { "dob", DOB.ToString("yyyy-MM-dd") }
        };

        StartCoroutine(SendPostRequest(REGISTER_USER_URL, parameters));
    }

    IEnumerator SendPostRequest(string url, Dictionary<string, string> parameters)
    {
        using (UnityWebRequest req = UnityWebRequest.Post(url, parameters))
        {
            yield return req.SendWebRequest(); // Correct 'yield'

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

    static bool HasErrorMessage(string msg)
    {
        // Custom error message checking logic
        return msg.Contains("error") || msg.Contains("fail");
    }

    public class CyberlyUser
    {
        public string f_name;
        public string l_name;
        public string user_name;
        public string password;
        public string email;
        public DateTime DOB;
    }
}
