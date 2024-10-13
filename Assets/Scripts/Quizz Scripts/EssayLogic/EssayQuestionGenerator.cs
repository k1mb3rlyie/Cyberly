using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Essay Question", menuName = "Quiz/EssayQuestions")]
public class EssayQuestionGenerator : ScriptableObject
{
    public string Question; // The question for the essay
    public string CorrectInput; // The correct input for the essay

    public void Validate()
    {
        if (string.IsNullOrEmpty(CorrectInput))
        {
            throw new ArgumentException("Incorrect. Input cannot be empty.");
        }
    }

    public bool IsAnswerCorrect(string userInput)
    {
        return string.Equals(userInput.Trim(), CorrectInput.Trim(), System.StringComparison.OrdinalIgnoreCase);
    }
}