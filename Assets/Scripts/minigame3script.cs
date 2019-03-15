using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class minigame3script : MonoBehaviour
{
    public Text instruction,timer;
    string ans_value;
    public Button b1, b2, b3, b4;
    string[] types = { "Correct Instruction", "Keyword Error", "Register Error", "Syntax Error" };
    string[] questions = { "MOV AX,BX", "ADD AX,BL", "SUB AX 0100H", "ADDC AX,BX", "COMP BX,[SI]", "MOV BQ,09",
            "AND AX,0008H","XOR AX 0098H","ROLL CX,1","ROR BL,CX","SUBT AX,BX","INC [BX" };
    string[] answers = { "Correct Instruction", "Register Error", "Syntax Error", "Keyword Error",
                         "Keyword Error", "Keyword Error","Correct Instruction","Syntax Error",
                         "Keyword Error","Register Error","Keyword Error","Syntax Error" };

    int bonus, qstval;
    int ran1;
    float count = 7f;
    int valu; int rana1, rana2, rana3, rana4;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        ran1 = Random.Range(0, questions.Length);
        instruction.text = questions[ran1];
        rana1 = Random.Range(0, types.Length);
        rana2 = Random.Range(0, types.Length);
        while (rana2 == rana1)
            rana2 = Random.Range(0, types.Length);
        rana3 = Random.Range(0, types.Length);
        while (rana3 == rana1 || rana3 == rana2)
            rana3 = Random.Range(0, types.Length);
        rana4 = Random.Range(0, types.Length);
        while (rana4 == rana1 || rana4 == rana2 || rana4==rana3)
            rana4 = Random.Range(0, types.Length);

        b1.GetComponentInChildren<Text>().text = types[rana1];
        b2.GetComponentInChildren<Text>().text = types[rana2];
        b3.GetComponentInChildren<Text>().text = types[rana3];
        b4.GetComponentInChildren<Text>().text = types[rana4];

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
            if (ans_value.Equals(answers[ran1]))
                timer.text = "Well Done";
            else
                timer.text = "Too Bad";
        }
    }
    public void firstOption()
    {
        ans_value = b1.GetComponentInChildren<Text>().text;
        valu = 1;
        if (ans_value.Equals(answers[ran1]))
        {
            timer.text = "Well Done";


            FindObjectOfType<GameSession>().updateStatus("Well done, this is the right answer");
            StartCoroutine(goToNextSceneSuccess());
        }
        else
        {
            timer.text = "Too Bad";
            StartCoroutine(goToNextScene());
            FindObjectOfType<GameSession>().updateStatus("Wrong Answer!. The correct answer is " + answers[ran1]);
        }



    }
    public void secondOption()
    {
        ans_value = b2.GetComponentInChildren<Text>().text;
        valu = 1;
        if (ans_value.Equals(answers[ran1]))
        {
            timer.text = "Well Done";


            FindObjectOfType<GameSession>().updateStatus("Well done, this is the right answer");
            StartCoroutine(goToNextSceneSuccess());
        }
        else
        {
            timer.text = "Too Bad";
            StartCoroutine(goToNextScene());
            FindObjectOfType<GameSession>().updateStatus("Wrong Answer!. The correct answer is " + answers[ran1]);
        }
            


    }
    public void thirdOption()
    {
        ans_value = b3.GetComponentInChildren<Text>().text;
        valu = 1;
        if (ans_value.Equals(answers[ran1]))
        {
            timer.text = "Well Done";


            FindObjectOfType<GameSession>().updateStatus("Well done, this is the right answer");
            StartCoroutine(goToNextSceneSuccess());
        }
        else
        {
            timer.text = "Too Bad";
            StartCoroutine(goToNextScene());
            FindObjectOfType<GameSession>().updateStatus("Wrong Answer!. The correct answer is " + answers[ran1]);
        }


    }
    public void fourthOption()
    {
        ans_value = b4.GetComponentInChildren<Text>().text;
        valu = 1;
        if (ans_value.Equals(answers[ran1]))
        {
            timer.text = "Well Done";


            FindObjectOfType<GameSession>().updateStatus("Well done, this is the right answer");
            StartCoroutine(goToNextSceneSuccess());
        }
        else
        {
            timer.text = "Too Bad";
            StartCoroutine(goToNextScene());
            FindObjectOfType<GameSession>().updateStatus("Wrong Answer!. The correct answer is " + answers[ran1]);
        }


    }
    IEnumerator goToNextScene()
    {
        yield return new WaitForSeconds(1.15f);
        FindObjectOfType<GameSession>().levelUp();
        SceneManager.LoadScene("intermediary");
    }

    IEnumerator goToNextSceneSuccess()
    {
        bonus = (int)System.Math.Floor(count);
        Debug.Log(bonus);
        score = 25 + bonus;
        FindObjectOfType<GameSession>().addToScore(score);
        FindObjectOfType<GameSession>().levelUp();
        yield return new WaitForSeconds(1.15f);
        SceneManager.LoadScene("intermediary");
    }
}
