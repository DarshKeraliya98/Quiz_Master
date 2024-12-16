using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    
    QuestionSO currentQuestion;

    [Header("Answers")] 
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnswerErly = true;

    [Header("Buttons Colors")]
    [SerializeField]Sprite defaultAnswerSprite;
    [SerializeField]Sprite CorrectAnswerSprite;

    [Header("Timers")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreSkepper scoreSkepper;

    [Header("ProgressBar")]

    [SerializeField] Slider progressBar;

    public bool isCorrect;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreSkepper = FindObjectOfType<ScoreSkepper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
        
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNewQuestion)
        {
             if(progressBar.value == progressBar.maxValue)
        {
            isCorrect = true;
            return;
        }
            hasAnswerErly = false;
            GetNextQuestion();
            timer.loadNewQuestion = false;
        }
        else if(!hasAnswerErly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void onAnswerSelected(int Index)
    {
        hasAnswerErly = true;
       DisplayAnswer(Index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score" + scoreSkepper.CalCulateScore() + "%";
       
    }
    void DisplayAnswer(int Index)
    {
         Image buttonImage;

        if(Index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[Index].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswerSprite;
            scoreSkepper.IncorrectAnswer();
            
        }
        else
        {
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            String correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Incorrect, the correct answer is: " + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswerSprite;
        }
    }

    void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            scoreSkepper.IncorrectQuestionSeen();
        }
    }

    void GetRandomQuestion()
    {
        
        int index = UnityEngine.Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
        
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();
    

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        } 
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprite()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
