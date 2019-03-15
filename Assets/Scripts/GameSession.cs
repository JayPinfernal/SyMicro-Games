using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0, level = 1;
    int life = 4;
    String status = "";
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int getScore()
    {
        return score;
    }
    public int getLevel()
    {
        return level;
    }
    public void addToScore(int scorevalue)
    {
        score += scorevalue;
    }
    public void levelUp()
    {
        level+=1;
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }

    public void updateStatus(String txt)
    {
        status = txt;
    }
    public String getStatus()
    {
        return status;
    }
}
