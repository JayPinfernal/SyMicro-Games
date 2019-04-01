using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bossStage1Script : MonoBehaviour
{

    [SerializeField] Button[] bits;
    public GameObject word;
    public GameObject gate;
    public Text bingo, bad;
    string ans = "", ans1, ans2, ans3, ans3s, ans4; int result = 0, verdict;
    float speed = 150f;
    private Animator anim;
    [SerializeField] Text instructions, stage;
    string[] ICW1_d0 = { "No ICW4 Needed", "ICW4 Needed" };
    string[] ICW1_d1 = { "Cascaded", "Single" };
    string[] ICW1_d2 = { "Interval of 8 bytes", "Interval of 4 bytes" };
    string[] ICW1_d3 = { "Edge Triggered", "Level Triggered" };


   

    // 

    int ran1, ran2, ran3, ran4, ran5, ran6, ran7, ran8, ran9;
    // Start is called before the first frame update
    void Start()
    {
        ran1 = Random.Range(0, ICW1_d0.Length); ran2 = Random.Range(0, ICW1_d1.Length); ran3 = Random.Range(0, ICW1_d2.Length);
        ran4 = Random.Range(0, ICW1_d3.Length);
        //  ran5 = Random.Range(0, ICW2_Interr.Length);
        anim = gate.GetComponent<Animator>();
        stage.text = "";
        bingo.gameObject.SetActive(false);
        bad.gameObject.SetActive(false);

        verdict = 1;
        firstStage();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void firstStage()
    {
        bits[0].GetComponentInChildren<Text>().text = "0"; bits[0].interactable = false;
        bits[1].GetComponentInChildren<Text>().text = "0"; bits[1].interactable = false;
        bits[2].GetComponentInChildren<Text>().text = "0"; bits[2].interactable = false;
        bits[3].GetComponentInChildren<Text>().text = "0"; bits[3].interactable = false;
        bits[4].GetComponentInChildren<Text>().text = "1"; bits[4].interactable = false;
        instructions.text = ICW1_d0[ran1] + "\n" + ICW1_d1[ran2] + "\n" + ICW1_d2[ran3] + "\n" + ICW1_d3[ran4];
        ans1 = "0001" + ran4.ToString() + ran3.ToString() + ran2.ToString() + ran1.ToString();
        if (ran1 == 1)
            FindObjectOfType<ICWSession>().setIC4(1);
        if (ran2 == 0)
            FindObjectOfType<ICWSession>().setCascade(1);

    }


    public void combinetext()
    {
        for (int i = 1; i < bits.Length; i++)
        {
            ans += bits[i].GetComponentInChildren<Text>().text;
        }
        Debug.Log(ans);
        if (ans.Equals(ans1))
        {
            bingo.gameObject.SetActive(true);
            stage.text = "ICW 2";
            StartCoroutine(nextStage());
        }
        else
        {

            bad.gameObject.SetActive(true);
            FindObjectOfType<ICWSession>().resetBoss();
            StartCoroutine(goHome());
        }
        //

    }

    IEnumerator nextStage()
    {
        word.SetActive(false);
        instructions.gameObject.SetActive(false);
        anim.Play("GateOpen", 0, 2.15f);

        yield return new WaitForSeconds(2.15f);
        bingo.gameObject.SetActive(false);
        bad.gameObject.SetActive(false);
        gate.SetActive(false);
        yield return new WaitForSeconds(2.75f);
        gate.SetActive(true);
        anim.Play("GateClose", 0, 2.15f);
        yield return new WaitForSeconds(2.15f);
        SceneManager.LoadScene("MTMG7-2");
    }

    IEnumerator goHome()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("StartScreen");
    }

    void setZeroes()
    {
        bits[0].GetComponentInChildren<Text>().text = "0"; bits[1].GetComponentInChildren<Text>().text = "0"; bits[2].GetComponentInChildren<Text>().text = "0";
        bits[3].GetComponentInChildren<Text>().text = "0"; bits[4].GetComponentInChildren<Text>().text = "0"; bits[5].GetComponentInChildren<Text>().text = "0";
        bits[6].GetComponentInChildren<Text>().text = "0"; bits[7].GetComponentInChildren<Text>().text = "0"; bits[8].GetComponentInChildren<Text>().text = "0";
    }

    public void setBtn1()
    {
        if (bits[0].GetComponentInChildren<Text>().text.Equals("0"))
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