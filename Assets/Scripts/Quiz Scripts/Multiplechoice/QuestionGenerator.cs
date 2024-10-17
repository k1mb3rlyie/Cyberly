using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName = "New Quetsion", menuName = "Quiz/Question")]// so tha i can manually input the questtion into unity





public class QuestionGenerator : ScriptableObject
{


    public string Question;


    public string[] Answers = new string[4];  // Array of 4 possible answers supposed to be a string




    [Range(0, 3)]
    public int CorrectAnswer;
    // Method to check if a given answer index is correct





    public bool IsAnswerCorrect(int selectedAnswerIndex)
    {
        return selectedAnswerIndex == CorrectAnswer;
    }
}

