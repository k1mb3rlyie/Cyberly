using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SQLLoginLogin : MonoBehaviour
{
    [SerializeField] private LoginManager loginManager;

    [Header("Login")]
    [SerializeField] InputField emailOrUsername;
    [SerializeField] InputField password;

    public void LoginButton()
    {
        if (loginManager == null)
        {
            Debug.LogError("Connect the monobehvaiour");
            return;
        }

        if (string.IsNullOrEmpty(emailOrUsername.text) || emailOrUsername.text.Length < 4 )
        {
            Debug.LogError("Invalid username email");
            return;
        }


        if (string.IsNullOrEmpty(password.text) || password.text.Length < 8)
        {
            Debug.LogError("Invalid Password");
            return;
        }

        StartCoroutine(loginManager.UserLogin(emailOrUsername.text, password.text));
    }
}