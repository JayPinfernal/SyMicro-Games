using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossgamescript : MonoBehaviour
{

    [SerializeField] Button[] bits;
    public GameObject word;
    public GameObject gate;
    string ans;
    float speed = 150f;
    private Animator anim;
    [SerializeField] Text instructions,stage;
    string[] ICW1_d0;
    string[] ICW1_d1;
    string[] ICW1_d2;
    string[] ICW1_d3;
    // Start is called before the first frame update
    void Start()
    {
        anim = gate.GetComponent<Animator>();
        instructions.text = "8086 Mode \nEdge Triggered";
        stage.text = "";
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void combinetext()
    {
        foreach(Button btn in bits)
        {
            ans += btn.GetComponentInChildren<Text>().text;
        }
        Debug.Log(ans);
        StartCoroutine(nextStage());
    }

    IEnumerator nextStage()
    {
        word.SetActive(false);
        instructions.gameObject.SetActive(false);
        anim.Play("GateOpen",0,2.15f);

        yield return new WaitForSeconds(2.15f);
        gate.SetActive(false);
        stage.text = "ICW 1";
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
