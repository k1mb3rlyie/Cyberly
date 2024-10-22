using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class SQLManager : MonoBehaviour
{
    readonly static string SERVER_URL = "localhost:80/CyberlyBackend/Cyberly";
    public static async Task<bool> NewUserReg(string f_name, string l_name, string user_name, string password, string email, DateTime DOB) //NewUserReg
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

        return await SendPostRequest(REGISTER_USER_URL, new );
    }

    static async Task<bool> SendPostRequest(string url, Dictionary<string, string> parameters)
    {
        using (UnityWebRequest req = UnityWebRequest.Post(url, parameters))
        {
            req.SendWebRequest();

            while (!req.isDone) await Task.Delay(100);

            // Checking for errors
            if (req.error != null || !string.IsNullOrWhiteSpace(req.error) || HasErrorMessage(req.downloadHandler.text))
                return false;

            return true; // Return true if no errors
        }
    }

    static bool HasErrorMessage(string msg) => int.TryParse(msg, out var res);

    // Optionally define HasErrorMessage() here if needed

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
