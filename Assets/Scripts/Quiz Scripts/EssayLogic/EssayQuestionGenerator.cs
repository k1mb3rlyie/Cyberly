using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EssayQuestionGenerator : MonoBehaviour
{
    public EssayQuestion question; // The question for the essay is a reference to our ScriptableObject...
    public InputField UserInput;   // The correct input for the essay
    public Text questionText;

    public Button submitButton;
    public Text timerText;

    // Time variables
    public float TimeLimit = 300f; // 5 mins for each question seems adequate
    private float Timer = 0f;
    private bool IsTimerRunning = true;

    private bool HasSubmitted = false;
    private string LastText = "";

    public GameObject EssayPanel;
    public GameObject GameOverPanel;

    void Start()
    {
        questionText.text = question.essayQuestions; // Display the essay question from the ScriptableObject
        EssayPanel.SetActive(true);
        GameOverPanel.SetActive(false);

        IsTimerRunning = true;

        submitButton.onClick.AddListener(SubmitAnswer);

        UserInput.onValueChanged.AddListener(HandleInputFieldChanged); //#
    }

    string FormatTime(float Time)
    {
        int minutes = Mathf.FloorToInt(Time / 60);
        int seconds = Mathf.FloorToInt(Time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //# 
    private void HandleInputFieldChanged(string input)
    {
        if (input.Length > LastText.Length + 1)
        {
            UserInput.text = LastText; //reserve last positions

            Debug.Log("Paste detected into input field");
        }
        else
        {
            LastText = input;
        }
    }

    void Update()
    {
        if (IsTimerRunning)
        {
            Timer += Time.deltaTime;
            float remainingTime = TimeLimit - Timer;
            timerText.text = FormatTime(remainingTime);

            if (remainingTime <= 0 && !HasSubmitted)
            {
                Debug.Log("Time's up, submitting the answer...");
                SubmitAnswer();
            }
        }
    }

    public void Validate()
    {
        string userAnswer = UserInput.text; //i will refer to this in the script that will collect the ansers for NLP assessment

        GameOverPanel.SetActive(true);
        EssayPanel.SetActive(false); //this shit didnt work once, but we thank God praise be!!!

        Debug.Log("User's Answer: " + userAnswer);
        Debug.Log("GameOverPanel Active: " + GameOverPanel.activeSelf);
    }

    public void SubmitAnswer()
    {
        if (HasSubmitted) return;
        Validate();
        HasSubmitted = true;
        submitButton.interactable = false;
        IsTimerRunning = false;

        Debug.Log("Answer submitted successfully.");
    }
}
