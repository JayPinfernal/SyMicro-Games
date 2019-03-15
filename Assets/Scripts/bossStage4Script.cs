
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class bossStage4Script : MonoBehaviour
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
    string[] ICW4_d0 = { "MCS-86/85 Mode" };
    string[] ICW4_d1 = { "Normal EOI"};
    string[] ICW4_d2 = { "Slave", "Master" };
    string[] ICW4_d3 = { "Non Buffered Mode", "Buffered Mode" };
    string[] ICW4_d4 = { "not special fully nested", "special fully nested" };
    int ran1,ran2,ran3,ran4,ran5;
    // Start is called before the first frame update
    void Start()
    {
        anim = gate.GetComponent<Animator>();
        stage.text = "";
        ran1 = Random.Range(0, ICW4_d0.Length ); ran2 = Random.Range(0, ICW4_d1.Length); ran3 = Random.Range(0, ICW4_d2.Length);
        ran4 = Random.Range(0, ICW4_d3.Length);ran5 = Random.Range(0, ICW4_d4.Length);
        bingo.gameObject.SetActive(false);
        bad.gameObject.SetActive(false);
        vena.gameObject.SetActive(false);
        verdict = 1;
        fourthStage();
    }

    private void fourthStage()
    {
        bits[0].GetComponentInChildren<Text>().text = "0"; bits[0].interactable = false;
        bits[1].GetComponentInChildren<Text>().text = "0"; bits[1].interactable = false;
        bits[2].GetComponentInChildren<Text>().text = "0"; bits[2].interactable = false;
        bits[3].GetComponentInChildren<Text>().text = "0"; bits[3].interactable = false;
        instructions.text = ICW4_d0[ran1] + "\n" + ICW4_d1[ran2] + "\n" + ICW4_d2[ran3] + "\n" + ICW4_d3[ran4]+"\n" + ICW4_d4[ran5];
        ans1 = "000"+ran5.ToString() + ran4.ToString() + ran3.ToString() + ran2.ToString() + ran1.ToString();
        Debug.Log(ans1);
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
            StartCoroutine(playVictory());
            FindObjectOfType<ICWSession>().resetBoss();
        }
        else
        {
            bad.gameObject.SetActive(true);
            FindObjectOfType<ICWSession>().resetBoss();
            StartCoroutine(goHome());

        }
            
        //

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
        SceneManager.LoadScene("StartScreen");
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
