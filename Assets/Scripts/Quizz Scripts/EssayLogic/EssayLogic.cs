/*YHINKING OF USING A FUZZYWUZZY ALGORITHM INSTEAD OF AN API...NOT SURE WHUCH IS BETTER */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssayLogic : MonoBehaviour
{
    public EssayQuestionGenerator essayQuestions; //reference to tihs script E\
    public InputField userInputField;
    public Text feedbackText;

    public void CheckAnswer()
    {
        string userInput = userInputField.text;
        bool isCorrect = essayQuestions.IsAnswerCorrect(userInput);


        if (isCorrect)
        {
            feedbackText.text = "Correct!!!";
        }

        else
        {
            feedbackText.text = "Incorrect. Try again";
        }
    }
}
