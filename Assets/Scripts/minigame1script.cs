
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class minigame1script : MonoBehaviour
{
   public Text timer,quest;
   public Button b1, b2, b3;
    string[] question = { "5V DC supply", "Used for processor operation", "Provides timing", "Carries low order byte data",
        "Carries higher order byte data", "Carries 4-bit address and status signals", "Used to indicate the transfer of data",
        "Used to read signal", "Acknowledgement signal from I/O devices that data is transferred", "Used to restart the execution",
        "Interrupt request signal", "An edge triggered input", "Wait for IDLE state", "Indicates what mode the processor is to operate in",
        "Acknowledges the interrupt", "Indicates the availability of a valid address", "Used to enable transreceiver 8286",
        "Decides the direction of data flow through the transreceiver", "Used to distinguish between memory and I/O operations",
        "Used to write the data", "Acknowledges the HOLD signal",
        "Indicates to the processor that external devices are requesting to access the address/data buses",
        "Provide the status of instruction queue", "Provide the status of operation",
        "Indicates to the other processors not to ask the CPU to leave the system bus",
        "Used by the other processors requesting the CPU to release the system bus" };
    string[] answer = { "VCC", "GND", "CLK", "AD0-AD7", "AD8-AD15", "AD16-AD19/S3-S6", "S7/BHE", "READ", "READY", "RESET", "INTR",
        "NMI", "TEST", "MN/MX", "INTA", "ALE", "DEN", "DT/R", "M/IO", "WR", "HLDA", "HOLD", "QS1/QS0", "S0/S1/S2", "LOCK", "RQ/GT0 & RQ/GT1" };
    string qstn;
    int ran1, ran2, ran3, ranq, qstval;
    int valu = 0,score;

     float count = 7;
    // Start is called before the first frame update
    void Start()
    {
        ran1 = Random.Range(0, answer.Length);
        ran2 = Random.Range(0, answer.Length);
        while (ran2 == ran1)
            ran2 = Random.Range(0, answer.Length);
        ran3 = Random.Range(0, answer.Length);
        while (ran3 == ran1 || ran3 == ran2)
            ran3 = Random.Range(0, answer.Length);

        b1.GetComponentInChildren<Text>().text = answer[ran1];
        b2.GetComponentInChildren<Text>().text = answer[ran2];
        b3.GetComponentInChildren<Text>().text = answer[ran3];
        ranq = Random.Range(1, 4);
        if(ranq == 1)
        {
            qstval = ran1;
            qstn = question[ran1];
        }
        if (ranq == 2)
        {
            qstval = ran2;
            qstn = question[ran2];
        }
        if (ranq == 3)
        {
            qstval = ran3;
            qstn = question[ran3];
        }
        quest.text=qstn;
        timer.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {   if (valu == 0)
        {
            if (count >= 0)
            {
                count = count - Time.deltaTime;
                timer.text = count.ToString();
            }
            else
            {
                timer.text = "Time is up";
                SceneManager.LoadScene("StartScreen");
            }
        }
        else if(valu == qstval)
        {
            timer.text = "Well Done";
            SceneManager.LoadScene("StartScreen");
            int bonus = (int)System.Math.Floor(count);
            score = 25 + bonus;
            FindObjectOfType<GameSession>().addToScore(score);
        }
        else
        {
            timer.text = "Too Bad";
            SceneManager.LoadScene("StartScreen");
        }
         


    }
    public void Opt1()
    {
        valu = ran1;
    }
    public void Opt2()
    {
        valu = ran2;
    }
    public void Opt3()
    {
        valu = ran3;
    }
}
