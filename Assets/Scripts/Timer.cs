using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{    
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowAnswer = 10f;

    public bool isAnsweringQuestion;

    public bool loadNewQuestion;

    public float fillFraction;
    float timeValue;

    public void CancelTimer()
    {
        timeValue = 0f;
    }
    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        timeValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timeValue > 0f)
            {
                fillFraction = timeValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timeValue = timeToShowAnswer;
            }
        }
        else
        {
            if(timeValue > 0f)
            {
                fillFraction = timeValue / timeToShowAnswer;
            }
            else
            {
                timeValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                loadNewQuestion = true;
            }
        }

        Debug.Log(timeValue+ ":" +isAnsweringQuestion+":"+fillFraction);
    }
}
