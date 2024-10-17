//I HOPE THE ONLY TYPOS YOU FIND ARE IN MY COMMENTS AND NOT MY CODE

                      /*WARNING*/

                 //PROCEED WITH CAUTION//
            //THIS CODE ISN'T CATUALLY SUPPOSED TO BE FUNNY
            //KNOW THAT I WAS DEADASS WHEN I WROTE IT
            //PLEASE DONT LAUGH AT IT


// THIS WAS SUPPOSED TO BE THE LOGIC FOR JUST THE QUIZ BUT I GOT LAZY
// AND JUST KEPT PUTTING ALL MY LOGIC HERE SO THIS WHOLE DOCUMENT IS
// A BIT  MESSY. 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


[System.Serializable]
public class GameLogic : MonoBehaviour
{

    //geneeration of questions stored in a list

    public List<QuestionGenerator> QnA;

    public GameObject[] options; //option set as array so that they will be a container of the same thing


    //VARIABLES FOR SCORE LOGIC
    public int TotalQuestions = 0;
    public int CurrentQuestions;
    public int Score = 0;
    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text LetterGradeTxt;

    public GameObject QuizPanel;     // refer to this panel in unity
    public GameObject GameOverPanel; // refer to this panel and disable the other in unity




    private void Start()
    {
        QuizPanel.SetActive(true);
        GameOverPanel.SetActive(false);
        TotalQuestions = QnA.Count;


        if (QuestionTxt == null)
        {
            Debug.LogError("QuestionTxt is not assigned in the Inspector!");
            return;  //Just stop further execution if it's null. unlikely but just in case
        }

        GenerateQuestions();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    //scoring logic. i want it to be calculated in %

    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        float PercentageScore = (Score / (float)TotalQuestions) * 100;
        ScoreTxt.text = PercentageScore.ToString() + "%";// BETTER COME BACK AND WRITE THE MATH TO SOLVE THIS GIRL.
                                                       // YOU DECIDED TO MAKE IT IN PERCENTAGE BECAUSE YOU DONT
                                                         // WANT TO HAVE AN EASY LIFE!
                    /*DONE!*/

                    //NOW TO GRADE IT CAUSE WHY NOT? MAKE IT MORE COMPLEX WHY DON'T YOU! 
        string LetterGrade = "";
        switch (PercentageScore)
        {
            case float n when (n >= 90):
                LetterGrade = "Fantastic A+";
                break;
            case float n when (n >= 80):
                LetterGrade = "A";
                break;
            case float n when (n >= 70):
                LetterGrade = "B";
                break;
            case float n when (n >= 60):
                LetterGrade = "C";
                break;
            case float n when (n >= 50):
                LetterGrade = "D";
                break;
            case float n when (n >= 40):
                LetterGrade = "E";
                break;
            default:
                LetterGrade = "F";
                break;
        }
        LetterGradeTxt.text = LetterGrade;      //  I ponder on the meanig of life and what it means
                                                //  when a text is not a string.
                                                //  alas the universe has not revealed to me

    }



    //coreect  nanswer logic still in the worls or i have made
    //an error while (assigning correctingIndex in Unity Editor

    public void Correct()
    {
        Score += 1;
        QnA.RemoveAt(CurrentQuestions);

        GenerateQuestions();

    }

    public void Wrong()
    {
        QnA.RemoveAt(CurrentQuestions);
        GenerateQuestions() ;
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = true;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[CurrentQuestions].Answers[i];
            
            //eh?

            if (QnA[CurrentQuestions].CorrectAnswer == i) // I WANT TO CRY. I HONESTLY CANT EVEN TELL YOU WHAT THIS IS
            {
                options[i].GetComponent<Answers>().isCorrect = false;
            }

        }
    }
    void GenerateQuestions()
    {
        if (QnA.Count > 0)
        {

            CurrentQuestions = UnityEngine.Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[CurrentQuestions].Question;

            SetAnswers();

        }

        else
        {
            Debug.Log("No questions left");
            GameOver();
        }

    }
}

//These Comments are not meant to be helpful to anyone