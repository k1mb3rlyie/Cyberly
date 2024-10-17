using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "New Essay Question", menuName = "Quiz/EssayQuestions")]
public class EssayQuestionGenerator : MonoBehaviour
{
    public EssayQuestion question; // The question for the essay
    public InputField UserInput; // The correct input for the essay
    public Text questionText;

    void Start()
    {
        questionText.text = question.essayQuestions;


    }

    public void Validate()
    {

        string userAnswer = UserInput.text; //i will refer to this in the script that will collect the ansers for NLP assessment



    }

}