using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToZone : MonoBehaviour
{
    [SerializeField] Text score,state;
    int ranzone,highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score.text = highscore.ToString();

        FindObjectOfType<GameSession>().updateStatus("Let's Go");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToTimer()
    {
        SceneManager.LoadScene("intermediary");
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
