using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreept endScreept;

    void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreept = FindObjectOfType<EndScreept>();
    }
    void Start()
    {
        quiz.gameObject.SetActive(true);
        endScreept.gameObject.SetActive(false);
    }

    void Update()
    {
        if(quiz.isCorrect)
        {
            endScreept.gameObject.SetActive(true);
            quiz.gameObject.SetActive(false);
            endScreept.FinalScore();
        }
    }

    public void OnReplyLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
