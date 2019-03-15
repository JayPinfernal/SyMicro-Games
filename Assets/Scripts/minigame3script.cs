using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class minigame3script : MonoBehaviour
{
    public Text instruction,timer;
    string ans_value;
    public Button b1, b2, b3, b4;
    string[] questions = { "MOV AX,BX", "ADD AX,BL", "SUB AX 0100H", "ADDC AX,BX", "COMP BX,[SI]", "MOV BQ,09",
            "AND AX,0008H","XOR AX 0098H","ROLL CX,1","ROR BL,CX","SUBT AX,BX","INC [BX" };
    string[] answers = { "Correct Instruction", "Register Error", "Syntax Error", "Keyword Error",
                         "Keyword Error", "Keyword Error","Correct Instruction","Syntax Error",
                         "Keyword Error","Register Error","Keyword Error","Syntax Error" };

    int bonus, qstval;
    int ran1, ran2;
    float count = 6f;
    int valu;
    // Start is called before the first frame update
    void Start()
    {
        ran1 = Random.Range(0, questions.Length);
        instruction.text = questions[ran1];
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
               // StartCoroutine(goToNextScene());
               // FindObjectOfType<GameSession>().updateStatus("Time Is Up sorry for the speed");
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
    public void firstoption()
    {
        ans_value = b1.GetComponentInChildren<Text>().text;
        if (ans_value.Equals(answers[ran1]))
            timer.text = "Well Done";
        else
            timer.text = "Too Bad";


    }
}
