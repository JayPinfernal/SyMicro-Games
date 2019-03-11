using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class minigame2script : MonoBehaviour
{
    float speed = 111f;
    String[] questions = { "BIU Stuff 1", "EU Stuff 1", "BIU Stuff 2", "EU Stuff 2", "BIU Stuff 3", "EU Stuff 3" };
    String[] answers = { "biu","eu", "biu", "eu", "biu", "eu" };
    Rigidbody2D rb2d;
    int ran,score=25;
    [SerializeField] Text theWill;
    // Start is called before the first frame update
    void Start()
    {
        ran = UnityEngine.Random.Range(1, questions.Length);
        gameObject.GetComponentInChildren<Text>().text = questions[ran];
    }

    // Update is called once per frame
    void Update()
    {
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
        
        var newYpos = Mathf.Clamp(transform.position.y + 150, 0, 471);
        var deltaX = Time.deltaTime * speed;
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, 0, 1946);
        transform.position = new Vector2(newXpos, newYpos);
    }

    void goDown()
    {
        
        var newYpos = Mathf.Clamp(transform.position.y - 150, 0, 471);
        var deltaX = Time.deltaTime * speed;
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, 0, 1946);
        transform.position = new Vector2(newXpos, newYpos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "end")
        {
            theWill.text = "OH NO !";
            SceneManager.LoadScene("StartScreen");
        }
        else if (collision.gameObject.tag == answers[ran])
        {
            theWill.text = "Well Done !";
           FindObjectOfType<GameSession>().addToScore(score);
            SceneManager.LoadScene("StartScreen");
        }
        else
        {
            theWill.text = "Wrong Part !";
            SceneManager.LoadScene("StartScreen");
        }
        
    }

}
