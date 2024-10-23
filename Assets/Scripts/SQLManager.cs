using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class SQLManager : MonoBehaviour
{
    readonly static string SERVER_URL = "http://localhost:80/CyberlyBackend/Backend/";

    public IEnumerator NewUserReg(string f_name, string l_name, string user_name, string email,  string password, DateTime DOB) //order in the UI
    {
        string REGISTER_USER_URL = $"{SERVER_URL}/register.php";

        var parameters = new Dictionary<string, string>
        {
            { "f_name", f_name },
            { "l_name", l_name },
            { "user_name", user_name },
            { "email", email },
            { "password", password },
            { "DOB", DOB.ToString("yyyy-MM-dd") }


        };

        foreach (var param in parameters)
        {
            Debug.Log($"{param.Key}: {param.Value}");
        }

        // Log the complete URL request
        Debug.Log($"Sending POST request to: {REGISTER_USER_URL}");


        yield return StartCoroutine(SendPostRequest(REGISTER_USER_URL, parameters));
    }



    private IEnumerator SendPostRequest(string url, Dictionary<string, string> parameters)
    {
        using (UnityWebRequest req = UnityWebRequest.Post(url, parameters))
        {
            req.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return req.SendWebRequest(); // Correct 'yield' must stop spelling it as yeild

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

    public class CyberlyUser
    {
        public string f_name;
        public string l_name;
        public string user_name;
        public string email;
        public string password;
        public DateTime DOB;
    }
}
