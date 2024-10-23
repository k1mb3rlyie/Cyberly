using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using TMPro;
using System;

public class SQLLogin : MonoBehaviour
{
    [Header("Register")]
    [SerializeField] InputField f_name;
    [SerializeField] InputField l_name;
    [SerializeField] InputField user_name;
    [SerializeField] InputField email;
    [SerializeField] InputField password;
    [SerializeField] TMP_InputField DOB;

    public async void OnSubmit()
    {
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
            return;
        }

        if (string.IsNullOrWhiteSpace(password.text) || password.text.Length < 5)
        {
            Debug.Log("Empty string or input is not long enough or is whitespace!! fill in the blank joor");
            return;
        }

        if (string.IsNullOrWhiteSpace(DOB.text))
        {
            Debug.Log("Date of Birth field is empty or whitespace!");
            return;
        }

        DateTime dob;
        if (!DateTime.TryParse(DOB.text, out dob))
        {
            Debug.Log("Not a valid date format!");
            return;
        }

        bool isSuccess = await SQLManager.NewUserReg(f_name.text, l_name.text, user_name.text, email.text, password.text, dob);

        if (isSuccess)
        {
            Debug.Log("User registered successfully!");
        }
        else
        {
            Debug.Log("Registration failed. Please try again.");
        }
    }

}
