using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class setTimer : MonoBehaviour
{
    Text timer;
    
    public float count = 10;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.GetComponent<Text>();
        timer.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
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
}
