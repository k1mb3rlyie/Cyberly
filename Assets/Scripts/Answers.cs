using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

[System.Serializable]
public class Answers : MonoBehaviour
{

    public bool isCorrect = false;

    public GameLogic gameLogic;


    public void Answer()
    {
        if (isCorrect)

        {
            Debug.Log("Correct");
            gameLogic.Correct();
        }

        else
        {
            Debug.Log("Incorrect");
            gameLogic.Wrong();
        }
    }
}