using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class intermediateScript : MonoBehaviour
{
    public Text score, state,level;
    public Image[] lives;
    int ranzone;
    string[] zones = { "MTMG1", "MTMG2", "MTMG5", "MTMG6" };
    string[] instructions = { "Select the correct 8086 pin", "Slect whether it is a part of biu or the eu",
        "Find the one with the greater priority","Select the correct task for the INT 21h"
    };
    string review;
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectOfType<GameSession>().getLevel() != 8)
        {
            ranzone = Random.Range(0, zones.Length);
            score.text = "Score :- " + FindObjectOfType<GameSession>().getScore().ToString();
            state.text = FindObjectOfType<GameSession>().getStatus();
            level.text = "";
            StartCoroutine(startLevel());
        }
        else
        {
            ranzone = Random.Range(0, zones.Length);
            score.text = "Score :- " + FindObjectOfType<GameSession>().getScore().ToString();
            state.text = FindObjectOfType<GameSession>().getStatus();
            level.text = "";
            StartCoroutine(playBoss());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startLevel()
    {
        yield return new WaitForSeconds(1.75f);
        level.text = "Level " + FindObjectOfType<GameSession>().getLevel().ToString();
        state.text = instructions[ranzone];
        yield return new WaitForSeconds(2.75f);
        SceneManager.LoadScene(zones[ranzone]); 
    }
    IEnumerator playBoss()
    {
        yield return new WaitForSeconds(1.25f);
        state.text = "IT'S BOSS TIME";
        yield return new WaitForSeconds(1.25f);
        level.text = "Level " + FindObjectOfType<GameSession>().getLevel().ToString();
        state.text = "Make the following ICWs";
        yield return new WaitForSeconds(2.75f);
        SceneManager.LoadScene("MTMG7-1");
    }
}
