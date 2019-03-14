using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossgamescript : MonoBehaviour
{

    [SerializeField] Button[] bits;
    public GameObject word;
    public GameObject gate;
    public Text bingo, bad;
    string ans="",ans1,ans2,ans3,ans3s,ans4; int result = 0,verdict;
    float speed = 150f;
    private Animator anim;
    [SerializeField] Text instructions, stage;
    string[] ICW1_d0 = { "No ICW4 Needed", "ICW4 Needed" };
    string[] ICW1_d1 = {"Cascaded", "Single"};
    string[] ICW1_d2 = { "Interval of 8 bytes", "Interval of 4 bytes" };
    string[] ICW1_d3 = { "Edge Triggered", "Level Triggered" };
    string[] ICW4_d0 = { "8086/8088 Mode", "MCS-86/85 Mode" };
    string[] ICW4_d1 = { "Auto EOI", "Cascaded" };
    string[] ICW4_d2 = { "Slave", "Master" };
    string[] ICW4_d3 = { "Non Buffered Mode", "Buffered Mode" };
    string[] ICW4_d4 = { "Level Triggered", "Edge Triggered" };

    string[] ICW2_Interr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "A", "B", "C", "1A", "1B", "1C", "1D", "1E", "1F", "4C", "AC", "FF" };
    string[] ICW2_Code = {"00000001","00000010","00000011","00000100","00000101","00000110","00000111","00001000","00001001","00010000","00010001","00010010","00010011","00010100","00010101","00001010","00001011","00001100",
                           "00011010","00011011","00011100","00011101","00011111","01001100","10101100","11111111"};

    string[] ICW3_Master = { "S0", "S1", "S2", "S3", "S4", "S5", "S6", "S7" };
    string[] ICW3_Slave = { "000", "001", "010", "011", "100", "101", "110", "111" };
                            
    int ran1, ran2, ran3, ran4, ran5, ran6, ran7, ran8, ran9;
    // Start is called before the first frame update
    void Start()
    {
        ran1 = Random.Range(0, ICW1_d0.Length); ran2 = Random.Range(0, ICW1_d1.Length); ran3 = Random.Range(0, ICW1_d2.Length);
        ran4 = Random.Range(0, ICW1_d3.Length);
        ran5 = Random.Range(0, ICW2_Interr.Length);
        anim = gate.GetComponent<Animator>();
        stage.text = "";
        bingo.gameObject.SetActive(false);
        bad.gameObject.SetActive(false);

        verdict = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(result == 0)
        {
            firstStage();
        }
        else
        {
            if (result == 1)
            {
                bingo.gameObject.SetActive(true);
                stage.text = "ICW 2";
            }
            else
            {
                bad.gameObject.SetActive(true);
            }
        }
       
    }

    void firstStage()
    {
        verdict = 1;
        bits[0].GetComponentInChildren<Text>().text = "0";bits[0].interactable = false;
        bits[1].GetComponentInChildren<Text>().text = "0"; bits[1].interactable = false;
        bits[2].GetComponentInChildren<Text>().text = "0"; bits[2].interactable = false;
        bits[3].GetComponentInChildren<Text>().text = "0"; bits[3].interactable = false;
        bits[4].GetComponentInChildren<Text>().text = "1"; bits[4].interactable = false;
        instructions.text = ICW1_d0[ran1]+"\n" + ICW1_d1[ran2] + "\n" + ICW1_d2[ran3] + "\n" + ICW1_d3[ran4];
        ans1 = "0001" + ran4.ToString() + ran3.ToString() + ran2.ToString() + ran1.ToString();
        

    }

    void secondStage()
    {
        verdict = 2;
        bits[0].GetComponentInChildren<Text>().text = "1"; bits[0].interactable = false;
    }

    void validator()
    {
        Debug.Log(ans1);
        switch (verdict)
        {
            
            case 1:
                if (ans.Equals(ans1))
                    result = 1;
                else
                    result = -1;
                break;
            case 2:
                if (ans.Equals(ans2))
                    result = 1;
                else
                    result = -1;
                break;
            case 3:
                if (ans.Equals(ans3))
                    result = 1;
                else
                    result = -1;
                break;
            case 4:
                if (ans.Equals(ans3s))
                    result = 1;
                else
                    result = -1;
                break;
            case 5:
                if (ans.Equals(ans4))
                    result = 1;
                else
                    result = -1;
                break;
            default:
                Debug.Log("CCC");
                break;

        }
    }

    public void combinetext()
    {
        for(int i=1; i < bits.Length; i++)
        {
            ans += bits[i].GetComponentInChildren<Text>().text;
        }
        Debug.Log(ans);
        validator();
        //StartCoroutine(nextStage());
    }

    IEnumerator nextStage()
    {
        word.SetActive(false);
        instructions.gameObject.SetActive(false);
        anim.Play("GateOpen",0,2.15f);

        yield return new WaitForSeconds(2.15f);
        gate.SetActive(false);
        yield return new WaitForSeconds(4.15f);
        gate.SetActive(true);
        anim.Play("GateClose", 0, 2.15f);
        yield return new WaitForSeconds(2.15f);
        instructions.gameObject.SetActive(true);
        word.SetActive(true);
    }


    public void setBtn1()
    {   if(bits[0].GetComponentInChildren<Text>().text.Equals("0"))
        bits[0].GetComponentInChildren<Text>().text = "1";
        else
            bits[0].GetComponentInChildren<Text>().text = "0";

    }
    public void setBtn2()
    {
        if (bits[1].GetComponentInChildren<Text>().text.Equals("0"))
            bits[1].GetComponentInChildren<Text>().text = "1";
        else
            bits[1].GetComponentInChildren<Text>().text = "0";

    }
    public void setBtn3()
    {
        if (bits[2].GetComponentInChildren<Text>().text.Equals("0"))
            bits[2].GetComponentInChildren<Text>().text = "1";
        else
            bits[2].GetComponentInChildren<Text>().text = "0";

    }
    public void setBtn4()
    {
        if (bits[3].GetComponentInChildren<Text>().text.Equals("0"))
            bits[3].GetComponentInChildren<Text>().text = "1";
        else
            bits[3].GetComponentInChildren<Text>().text = "0";

    }
    public void setBtn5()
    {
        if (bits[4].GetComponentInChildren<Text>().text.Equals("0"))
            bits[4].GetComponentInChildren<Text>().text = "1";
        else
            bits[4].GetComponentInChildren<Text>().text = "0";

    }
    public void setBtn6()
    {
        if (bits[5].GetComponentInChildren<Text>().text.Equals("0"))
            bits[5].GetComponentInChildren<Text>().text = "1";
        else
            bits[5].GetComponentInChildren<Text>().text = "0";

    }
    public void setBtn7()
    {
        if (bits[6].GetComponentInChildren<Text>().text.Equals("0"))
            bits[6].GetComponentInChildren<Text>().text = "1";
        else
            bits[6].GetComponentInChildren<Text>().text = "0";

    }
    public void setBtn8()
    {
        if (bits[7].GetComponentInChildren<Text>().text.Equals("0"))
            bits[7].GetComponentInChildren<Text>().text = "1";
        else
            bits[7].GetComponentInChildren<Text>().text = "0";

    }
    public void setBtn9()
    {
        if (bits[8].GetComponentInChildren<Text>().text.Equals("0"))
            bits[8].GetComponentInChildren<Text>().text = "1";
        else
            bits[8].GetComponentInChildren<Text>().text = "0";

    }


}
