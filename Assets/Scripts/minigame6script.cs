using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class minigame6script : MonoBehaviour
{
    public Text timer, quest;
    public Button b1, b2, b3;
    string[] ah_code = { "01", "02", "09", "0A", "4C" };
    string[] ah_task = { "Read Character to STDIN", "Write Character to STDOUT", "Write String to STDOUT", "Buffered Input", "Exit Program" };
    string qstn;
    int ran1, ran2, ran3, ranq, qstval;
    int valu = 0, score;
    int bonus;
    float count = 7;
    // Start is called before the first frame update
    void Start()
    {
        ran1 = Random.Range(0, ah_task.Length);
        ran2 = Random.Range(0, ah_task.Length);
        while (ran2 == ran1)
            ran2 = Random.Range(0, ah_task.Length);
        ran3 = Random.Range(0, ah_task.Length);
        while (ran3 == ran1 || ran3 == ran2)
            ran3 = Random.Range(0, ah_task.Length);

        b1.GetComponentInChildren<Text>().text = ah_task[ran1];
        b2.GetComponentInChildren<Text>().text = ah_task[ran2];
        b3.GetComponentInChildren<Text>().text = ah_task[ran3];
        ranq = Random.Range(1,4);
        if (ranq == 1)
        {
            qstval = ran1;
            qstn = ah_code[ran1];
        }
        if (ranq == 2)
        {
            qstval = ran2;
            qstn = ah_code[ran2];
        }
        if (ranq == 3)
        {
            qstval = ran3;
            qstn = ah_code[ran3];
        }
        quest.text = "mov ah,"+qstn+"h\nint 21h";
        timer.text = count.ToString();
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


          FindObjectOfType<GameSession>().updateStatus("Well done, this is the right answer");
            StartCoroutine(goToNextSceneSuccess());
        }
        else
        {
            timer.text = "Too Bad";
            StartCoroutine(goToNextScene());
            FindObjectOfType<GameSession>().updateStatus("Wrong Answer!. The correct answer is " + ah_task[qstval]);
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
            FindObjectOfType<GameSession>().updateStatus("Wrong Answer!. The correct answer is " + ah_task[qstval]);
        }
    }
    public void Opt3()
    {
        valu = ran3;
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
           FindObjectOfType<GameSession>().updateStatus("Wrong Answer!. The correct answer is " + ah_task[qstval]);
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
        score = 30 + bonus;
        FindObjectOfType<GameSession>().addToScore(score);
        FindObjectOfType<GameSession>().levelUp();
        yield return new WaitForSeconds(1.15f);
        SceneManager.LoadScene("intermediary");
    }
}
