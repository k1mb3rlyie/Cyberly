using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "New Essay Question", menuName = "Quiz/EssayQuestions")]
public class EssayQuestionGenerator : ScriptableObject
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

        string userAnswer = UserInput.text;


    }

}