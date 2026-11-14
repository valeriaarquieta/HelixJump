using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public int bestScore;
    public int currentScore;
    public int currentLevel;
    public static GameManager singleton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        } else if (singleton!= this)
        {
            Destroy(gameObject);
        }
        bestScore=PlayerPrefs.GetInt("HighScore");
    }

    public void NextLevel()
    {
         Debug.Log("Pasamos de nivel");
         currentLevel ++;
         FindAnyObjectByType<BallController>().ResetBall();
         FindAnyObjectByType<HelixController>().LoadStage(currentLevel);

    }
    public void RestartLevel()
    {
         Debug.Log("rESTART");
         singleton.currentScore = 0;
         FindAnyObjectByType<BallController>().ResetBall();
         FindAnyObjectByType<HelixController>().LoadStage(currentLevel);
    }
    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if (currentScore>bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore",currentScore);
        }
    }


}
