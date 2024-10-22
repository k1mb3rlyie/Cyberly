using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using TMPro;

public class SQLLogin : MonoBehaviour
{
    [Header("Register")]
    [SerializeField] InputField f_name;
    [SerializeField] InputField l_name;
    [SerializeField] InputField user_name;
    [SerializeField] InputField email;
    [SerializeField] InputField password;
    [SerializeField] TMP_InputField DOB;

    public void OnSubmit()
    {
        //if (string.IsNullOrWhiteSpace(f_name.text, l_name.text, user_name.text, email.text, password.text, birthday.text) // oveload apparently cant take six arguments
        //{
        //    Debug.Log("Empty string or imput is whitespace!! fill in the blank joor");

        //    return;
        //}

        if (string.IsNullOrWhiteSpace(f_name.text) || f_name.text.Length < 3)
        {
            Debug.Log("Empty string or imput is not long enough or is whitespace!! fill in the blank joor");

            return;
        }

        if (string.IsNullOrWhiteSpace(l_name.text) || l_name.text.Length < 3)
        {
            Debug.Log("Empty string or imput is not long enough or is whitespace!! fill in the blank joor");

            return;
        }

        if (string.IsNullOrWhiteSpace(user_name.text) || user_name.text.Length < 7)
        {
            Debug.Log("Empty string or imput is not long enough or is whitespace!! fill in the blank joor");

            return;
        }

        if (string.IsNullOrWhiteSpace(email.text) || email.text.Length < 4) // oveload apparently cant take six arguments
        {
            Debug.Log("Empty string or imput is whitespace!! fill in the blank joor");

            return;
        }

        if (string.IsNullOrWhiteSpace(password.text) || password.text.Length < 5)
        {

            Debug.Log("Empty string or imput is not long enough or is whitespace!! fill in the blank joor");

            return;
        }

        if (string.IsNullOrWhiteSpace(DOB.text) || DOB.text.Length < 6) // oveload apparently cant take six arguments
        {
            Debug.Log("Empty string or imput is not long enough or is whitespace!! fill in the blank joor")

            return;
        }

        SQLManager.NewUserReg(f_name.text, l_name.text, user_name.text, email.text, password.text, DOB.text);
    }
}
