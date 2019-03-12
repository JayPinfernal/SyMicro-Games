using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToZone : MonoBehaviour
{
    [SerializeField] Text score;
    string[] zones = { "MTMG1", "MTMG2" };
    int ranzone;
    // Start is called before the first frame update
    void Start()
    {
        ranzone = Random.Range(0, zones.Length);
        score.text = FindObjectOfType<GameSession>().getScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToTimer()
    {
        SceneManager.LoadScene(zones[ranzone]);
    }

	public void exitGame()
	{
	#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
	#else
		Application.Quit();
	#endif
	}

}
