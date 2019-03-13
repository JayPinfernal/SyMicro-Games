using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class minigame2script : MonoBehaviour
{
    float speed = 171f;
    String[] questions = { "BIU Stuff 1", "EU Stuff 1", "BIU Stuff 2", "EU Stuff 2", "BIU Stuff 3", "EU Stuff 3" };
    String[] answers = { "biu","eu", "biu", "eu", "biu", "eu" };
    Rigidbody2D rb2d;
    int ran,score=25;
    [SerializeField] Text theWill;
    [SerializeField] Sprite beat;
    [SerializeField] Image pulse;
    int pts = 0;
    // Start is called before the first frame update
    void Start()
    {
        ran = UnityEngine.Random.Range(1, questions.Length);
        gameObject.GetComponentInChildren<Text>().text = questions[ran];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pts==0)
        StrafeLeft();
    }

    private void StrafeLeft()
    {
        var deltaX = Time.deltaTime * speed;
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, 0, 1946);
        transform.position = new Vector2(newXpos, transform.position.y);
    }

    void FixedUpdate()
    {
      
    }

    public void upBtn()
    {
        goUp();
    }

    public void dwnBtn()
    {
        goDown();
    }

    void goUp()
    {
        
        var newYpos = Mathf.Clamp(transform.position.y + 35, 0, 871);
        var deltaX = Time.deltaTime * speed;
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, 0, 1946);
        transform.position = new Vector2(newXpos, newYpos);
        Debug.Log("New y position is " + newYpos);
    }

    void goDown()
    {
        
        var newYpos = Mathf.Clamp(transform.position.y - 35, 0, 871);
        var deltaX = Time.deltaTime * speed;
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, 0, 1946);
        transform.position = new Vector2(newXpos, newYpos);
        Debug.Log("New y position is " + newYpos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "end")
        {
            theWill.text = "OH NO !";
            
            FindObjectOfType<GameSession>().updateStatus("OOF, BADLY CRASHED! Hope you're fine");
            StartCoroutine(goToNextScene());
        }
        else if (collision.gameObject.tag == answers[ran])
        {
            pts = 1;
            
            theWill.text = "Well Done !";
           FindObjectOfType<GameSession>().addToScore(score);
            StartCoroutine(lifeLine());
            FindObjectOfType<GameSession>().updateStatus("Well done, this is the right answer");
            StartCoroutine(goToNextScene());
        }
        else
        {
            pts = 1;
            theWill.text = "Wrong Part !";
             FindObjectOfType<GameSession>().updateStatus("Sorry but "+questions[ran]+" involves "+ answers[ran] );
            StartCoroutine(goToNextScene());
        }
        
    }

    IEnumerator lifeLine()
    {
        pulse.sprite = beat;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator goToNextScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("StartScreen");
    }

}
