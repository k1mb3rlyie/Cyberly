/*YHINKING OF USING A FUZZYWUZZY ALGORITHM INSTEAD OF AN API...NOT SURE WHUCH IS BETTER */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "EssayQuiz", menuName = "Essays/Essay")] //love this method

public class EssayQuestion : ScriptableObject // cant use input field i have to use monobehaviour for that refer to this in the EssayGenerator script 
{
    public string essayQuestions; //reference to tihs script E\

}