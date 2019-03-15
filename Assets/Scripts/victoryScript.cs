using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class victoryScript : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score :- " + FindObjectOfType<GameSession>().getScore().ToString();
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
