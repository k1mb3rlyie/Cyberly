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

    public GameObject EssayPanel;
    public GameObject GameOverPanel;

    void Start()
    {
        questionText.text = question.essayQuestions;
        EssayPanel.SetActive(true);
        GameOverPanel.SetActive(false);

    }

    public void Validate()
    {

        string userAnswer = UserInput.text; //i will refer to this in the script that will collect the ansers for NLP assessment
        GameOverPanel.SetActive(true);
        EssayPanel.SetActive(false); //this shit didnt work once, but we thank God praise be!!!


    }

}