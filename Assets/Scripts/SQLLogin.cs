using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using TMPro;
using System;


public class SQLLogin : MonoBehaviour

{
    //SQLManager sqlManager = new SQLManager(); error add monobehaviour as serializable field (this method is shorter) and add it in the Unity UI or make it private

    [SerializeField] private SQLManager sqlManager;

    [Header("Register")]
    [SerializeField] InputField f_name;
    [SerializeField] InputField l_name;
    [SerializeField] InputField user_name;
    [SerializeField] InputField email;
    [SerializeField] InputField password;
    [SerializeField] TMP_InputField dobInputField;

    public void OnSubmit()
    {
        if (sqlManager == null)
        {
            Debug.LogError("SQLManager issue still unsolved");
            return;
        }
        if (string.IsNullOrWhiteSpace(f_name.text) || f_name.text.Length < 3)
        {
            Debug.Log("Invalid first name");
            return;
        }

        if (string.IsNullOrWhiteSpace(l_name.text) || l_name.text.Length < 3)
        {
            Debug.Log("Invalid last name");
            return;
        }

        if (string.IsNullOrWhiteSpace(user_name.text) || user_name.text.Length < 7)
        {
            Debug.Log("Username must be a string and more than 6 characters");
            return;
        }

        if (string.IsNullOrWhiteSpace(email.text) || email.text.Length < 4)
        {
            Debug.Log("Invalid Email address");
            Debug.Log("Email entered: " + email.text);

            return;
        }

        if (string.IsNullOrWhiteSpace(password.text) || password.text.Length < 8)
        {
            Debug.Log("Empty string or input is not long enough or is whitespace!! fill in the blank joor");
            return;
        }

        if (string.IsNullOrWhiteSpace(dobInputField.text))
        {
            Debug.Log("Date of Birth field is empty or whitespace!");
            return;
        }

        DateTime DOB;
        if (!DateTime.TryParse(dobInputField.text, out DOB))
        {
            Debug.Log("Not a valid date format!");
            return;
        }

        StartCoroutine(sqlManager.NewUserReg(f_name.text, l_name.text, user_name.text, email.text, password.text, DOB)); //make the same order in the UII as well
    }

    //i wonder if i can make the same script call the login functionas as well   ?
     
}
