using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bossStage3SlaveScript : MonoBehaviour
{
    [SerializeField] Button[] bits;
    public GameObject word;
    public GameObject gate;
    public Button subm;
    public Image vena;
    public Text bingo, bad;
    string ans = "", ans1, ans2, ans3, ans3s, ans4; int result = 0, verdict;
    float speed = 150f;
    int mast, ic4;
    private Animator anim;
    [SerializeField] Text instructions, stage;
    int ran1;
    string[] ICW3_Slave = { "000", "001", "010", "011", "100", "101", "110", "111" };
    // Start is called before the first frame update
    void Start()
    {
        
        anim = gate.GetComponent<Animator>();
        stage.text = "";
        bingo.gameObject.SetActive(false);
        bad.gameObject.SetActive(false);
        mast = FindObjectOfType<ICWSession>().getMaster();
        ic4 = FindObjectOfType<ICWSession>().getIC4();
        vena.gameObject.SetActive(false);
        verdict = 1;
        thirdStage();
    }

    private void thirdStage()
    {
        instructions.text = "Slave Device for master S" + mast.ToString();
        bits[0].GetComponentInChildren<Text>().text = "1"; bits[0].interactable = false;
        bits[1].GetComponentInChildren<Text>().text = "0"; bits[1].interactable = false;
        bits[2].GetComponentInChildren<Text>().text = "0"; bits[2].interactable = false;
        bits[3].GetComponentInChildren<Text>().text = "0"; bits[3].interactable = false;
        bits[4].GetComponentInChildren<Text>().text = "0"; bits[4].interactable = false;
        bits[5].GetComponentInChildren<Text>().text = "0"; bits[5].interactable = false;
        ans1 = ICW3_Slave[mast];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void combinetext()
    {
        for (int i = 6; i < bits.Length; i++)
        {
            ans += bits[i].GetComponentInChildren<Text>().text;
        }
        Debug.Log(ans);
        if (ans.Equals(ans1))
        {
            bingo.gameObject.SetActive(true);
             if (ic4 == 1)
            {
                Debug.Log(ic4);
                stage.text = "ICW4";
                FindObjectOfType<GameSession>().addToScore(250);
                StartCoroutine(nextStage4());
            }
            else
            {
                
                Debug.Log(ic4);
                FindObjectOfType<ICWSession>().resetBoss();
                StartCoroutine(playVictory());
                
            }
        }
        else
        {
            bad.gameObject.SetActive(true);
            FindObjectOfType<ICWSession>().resetBoss();
            StartCoroutine(goHome());
        }

        //

    }

    IEnumerator nextStage4()
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
        SceneManager.LoadScene("MTMG7-4");
    }

    IEnumerator playVictory()
    {
        vena.gameObject.SetActive(true);
        word.SetActive(false);
        instructions.gameObject.SetActive(false);
        anim.Play("GateOpen", 0, 2.15f);
        subm.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.15f);
        bingo.gameObject.SetActive(false);
        bad.gameObject.SetActive(false);
        gate.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Victory");
    }

    IEnumerator goHome()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("intermediary");
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
