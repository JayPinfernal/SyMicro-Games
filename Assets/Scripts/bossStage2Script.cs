using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class bossStage2Script : MonoBehaviour
{
    [SerializeField] Button[] bits;
    public GameObject word;
    public GameObject gate;
    public Button subm;
    public Image vena;
    public Text bingo, bad;
    string ans = "", ans1, ans2, ans3, ans3s, ans4; int result = 0, verdict;
    float speed = 150f;
    int casc, ic4;
    private Animator anim;
    [SerializeField] Text instructions, stage;
     string[] ICW2_Interr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "A", "B", "C", "1A", "1B", "1C", "1D", "1E", "1F", "4C", "AC", "FF" };
    string[] ICW2_Code = {"00000001","00000010","00000011","00000100","00000101","00000110","00000111","00001000","00001001","00010000","00010001","00010010","00010011","00010100","00010101","00001010","00001011","00001100",
                      "00011010","00011011","00011100","00011101","00011111","01001100","10101100","11111111","11111111"};
    int ran1, ran2;

    // Start is called before the first frame update
    void Start()
    {
        ran1 = Random.Range(0, ICW2_Interr.Length);
        anim = gate.GetComponent<Animator>();
        stage.text = "";
        bingo.gameObject.SetActive(false);
        bad.gameObject.SetActive(false);
        casc = FindObjectOfType<ICWSession>().getCascade();
        ic4 = FindObjectOfType<ICWSession>().getIC4();
        vena.gameObject.SetActive(false);
        verdict = 1;
        secondStage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void secondStage()
    {
        bits[0].GetComponentInChildren<Text>().text = "1"; bits[0].interactable = false;
        bits[1].interactable = true; bits[2].interactable = true; bits[3].interactable = true; bits[4].interactable = true;
        instructions.text = "Write ICW2 for the instruction code " + ICW2_Interr[ran1] ;
        ans2 = ICW2_Code[ran1];
        Debug.Log(ans2);
    }
    public void combinetext()
    {
        for (int i = 1; i < bits.Length; i++)
        {
            ans += bits[i].GetComponentInChildren<Text>().text;
        }
        Debug.Log(ans);
        if (ans.Equals(ans2))
        {
            bingo.gameObject.SetActive(true);
            if(casc==1 )
            {
                Debug.Log(casc);
                stage.text = "ICW3";
                StartCoroutine(nextStage3());
            }
            else if (ic4 == 1)
            {
                Debug.Log(ic4);
                stage.text = "ICW4";
                StartCoroutine(nextStage4());
            }
            else
            {
                Debug.Log(casc);
                Debug.Log(ic4);
                StartCoroutine(playVictory());
                FindObjectOfType<ICWSession>().resetBoss();
            }
        }
        else
        {
            bad.gameObject.SetActive(true);

        }
        
        //

    }
    IEnumerator nextStage3()
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
        SceneManager.LoadScene("MTMG7-3Master");
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
