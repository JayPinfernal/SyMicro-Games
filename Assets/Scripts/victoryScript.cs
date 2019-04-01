using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class victoryScript : MonoBehaviour
{
    public Text score,high;
    int totscore, highscore;
    // Start is called before the first frame update
    void Start()
    {
        totscore = FindObjectOfType<GameSession>().getScore();
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score.text = "Score :- " + FindObjectOfType<GameSession>().getScore().ToString();

        if(totscore > highscore)
        {
            PlayerPrefs.SetInt("highscore", totscore);
        }
        high.text = "High Score :- "+PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goHome()
    {
        FindObjectOfType<GameSession>().resetGame();
        SceneManager.LoadScene("StartScreen");
    }

    public void exitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
