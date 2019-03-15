
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class bossStage3MasterScript : MonoBehaviour
{
    [SerializeField] Button[] bits;
    public GameObject word;
    public GameObject gate;
    public Button subm;
    public Text bingo, bad;
    string ans = "", ans1, ans2, ans3, ans3s, ans4; int result = 0, verdict;
    float speed = 150f;
    int casc, ic4;
    private Animator anim;
    [SerializeField] Text instructions, stage;
    int ran1, ran2;

    string[] ICW3_Master = { "S0", "S1", "S2", "S3", "S4", "S5", "S6", "S7" };
    string[] ICW3_Master_Code = { "00000001", "00000010", "00000100", "00001000", "00010000", "00100000", "01000000", "10000000" };
    // Start is called before the first frame update
    void Start()
    {
        anim = gate.GetComponent<Animator>();
        stage.text = "";
        bingo.gameObject.SetActive(false);
        ran1 = Random.Range(0, ICW3_Master.Length);
        bad.gameObject.SetActive(false);
        ic4 = FindObjectOfType<ICWSession>().getIC4();
        
        verdict = 1;
        thirdStage();
    }

    private void thirdStage()
    {
        bits[0].GetComponentInChildren<Text>().text = "1"; bits[0].interactable = false;
        instructions.text = ICW3_Master[ran1] + " has a slave. Point out";
        ans3 = ICW3_Master_Code[ran1];
    }
    public void combinetext()
    {
        for (int i = 1; i < bits.Length; i++)
        {
            ans += bits[i].GetComponentInChildren<Text>().text;
        }
        Debug.Log(ans);
        if (ans.Equals(ans3))
        {
            bingo.gameObject.SetActive(true);
            stage.text = "ICW3-S";
            FindObjectOfType<GameSession>().addToScore(250);
            FindObjectOfType<ICWSession>().setMaster(ran1);
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
        subm.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
        anim.Play("GateOpen", 0, 2.15f);
        subm.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.15f);
        bingo.gameObject.SetActive(false);
        bad.gameObject.SetActive(false);
        gate.SetActive(false);
        yield return new WaitForSeconds(2.75f);
        gate.SetActive(true);
        anim.Play("GateClose", 0, 2.15f);
        yield return new WaitForSeconds(2.15f);
        SceneManager.LoadScene("MTMG7-3Slave");
    }

    IEnumerator goHome()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("StartScreen");
    }
    // Update is called once per frame
    void Update()
    {
        
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
