using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreept : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    ScoreSkepper scoreSkepper;

    void Awake()
    {
        scoreSkepper = FindObjectOfType<ScoreSkepper>();
    }

    public void FinalScore()
    {
        finalScore.text = "Congratulations! \n You got a score of  " + scoreSkepper.CalCulateScore() + "%";
    }
}
