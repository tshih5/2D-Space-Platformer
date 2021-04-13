using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public Text highScore;
    public Text highScoreTime;
    public int score = 0;
    public bool reset = true;
    public Scene scene;
    public string sceneName;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore" + sceneName, 0).ToString();
        highScoreTime.text = PlayerPrefs.GetString("HighScore" + sceneName + "Time", "0:00:00");
    }
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        UpdateScore(scene.name);
        
        //maybe move reset() somewhere else, such as main menu? i just have it here to quickly clear high score lol
        if (reset)
        {
            Reset(scene.name);
        }
    }

    public void UpdateScore(string sceneName)
    {
        //score += points;
        scoreText.text = "Score: " + score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore" + sceneName, 0))
        {
            GameTimeScript gametime = GameObject.Find("GameTimeDisplay").GetComponent<GameTimeScript>();

            PlayerPrefs.SetInt("HighScore" + sceneName, score);
            PlayerPrefs.SetString("HighScore" + sceneName + "Time", gametime.GetTimeText());
            highScore.text = "High Score: " + score.ToString();
            highScoreTime.text = gametime.GetTimeText();
        }
    }

    public void Reset(string sceneName)
    {
        PlayerPrefs.DeleteKey("HighScore" + sceneName);
        PlayerPrefs.DeleteKey("HighScore" + sceneName + "Time");
        highScore.text = "High Score: 0";
        highScoreTime.text = "0:00:00";
    }
}
