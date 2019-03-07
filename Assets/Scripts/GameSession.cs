using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0, value = 0;

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
    public int getValue()
    {
        return value;
    }
    public void addToScore(int scorevalue)
    {
        score += scorevalue;
    }
    public void setValue(int val)
    {
        value = val;
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }
}
