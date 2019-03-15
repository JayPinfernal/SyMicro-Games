using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class minigame5script : MonoBehaviour
{
    public Text timer;
    public Button b1, b2;
    string[] interrupts = { "Single-Step", "INTR", "NMI", "Divide By 0" };
    int valu = 0, score;
    int bonus,qstval;
    int ran1, ran2;
    float count = 6f;
    // Start is called before the first frame update
    void Start()
    {
        ran1 = Random.Range(0, interrupts.Length);
        ran2 = Random.Range(0, interrupts.Length);
        while (ran2 == ran1)
            ran2 = Random.Range(0, interrupts.Length);
        b1.GetComponentInChildren<Text>().text = interrupts[ran1];
        b2.GetComponentInChildren<Text>().text = interrupts[ran2];
        if (ran1 > ran2)
            qstval = ran1;
        else
            qstval = ran2;
    }

    // Update is called once per frame
    void Update()
    {
        if (valu == 0)
        {
            if (count >= 0)
            {
                count = count - Time.deltaTime;
                timer.text = count.ToString();
            }
            else
            {
                timer.text = "Time is up";
                StartCoroutine(goToNextScene());
               FindObjectOfType<GameSession>().updateStatus("Time Is Up sorry for the speed");
            }
        }
        else
        {
            if (valu == qstval)
                timer.text = "Well Done";
            else
                timer.text = "Too Bad";
        }
    }
    public void Opt1()
    {
        valu = ran1;
        if (valu == qstval)
        {
            timer.text = "Well Done";


           FindObjectOfType<GameSession>().updateStatus(interrupts[qstval] + " has a greater priority");
            StartCoroutine(goToNextSceneSuccess());
        }
        else
        {
            timer.text = "Too Bad";
            StartCoroutine(goToNextScene());
           FindObjectOfType<GameSession>().updateStatus(interrupts[qstval] + " has a greater priority");
        }
    }
    public void Opt2()
    {
        valu = ran2;
        if (valu == qstval)
        {
            timer.text = "Well Done";



          FindObjectOfType<GameSession>().updateStatus("Well done, this is the right answer");
            StartCoroutine(goToNextSceneSuccess());
        }
        else
        {
            timer.text = "Too Bad";
            StartCoroutine(goToNextScene());
           FindObjectOfType<GameSession>().updateStatus(interrupts[qstval] + " has a greater priority");
        }
    }
    IEnumerator goToNextScene()
    {
        FindObjectOfType<GameSession>().levelUp();
        yield return new WaitForSeconds(1.15f);
        
        SceneManager.LoadScene("intermediary");
    }
    IEnumerator goToNextSceneSuccess()
    {
        bonus = (int)System.Math.Floor(count);
        Debug.Log(bonus);
        score = 20 + bonus;
       FindObjectOfType<GameSession>().addToScore(score);
        FindObjectOfType<GameSession>().levelUp();
        yield return new WaitForSeconds(1.15f);

        SceneManager.LoadScene("intermediary");
    }
}
