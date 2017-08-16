using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Text highScoreText;
    
    // Use this for initialization
	void Start () {
        highScoreText.text = "High Score : " + (int)PlayerPrefs.GetFloat("Highscore"); 
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void ToGame()
    {
        SceneManager.LoadScene("EndlessRunner");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
