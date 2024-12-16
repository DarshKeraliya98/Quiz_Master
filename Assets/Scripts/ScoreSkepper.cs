using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSkepper : MonoBehaviour
{
   int correctAnswer = 0;
   int questionSeen = 0;
   
   public int GetCorrectAnswer()
   {
     return correctAnswer;
   }

   public void IncorrectAnswer()
   {
     correctAnswer++;
   }

   public int GetQuestionSeen()
   {
     return questionSeen;
   }
   public void IncorrectQuestionSeen()
   {
     questionSeen++;
   }

   public int CalCulateScore()
   {
     return Mathf.RoundToInt( correctAnswer  / (float)questionSeen * 100);
   }
}
