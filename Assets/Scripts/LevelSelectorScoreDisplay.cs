using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorScoreDisplay : MonoBehaviour
{

    public Text highScore;
    public Text highScoreTime;
    public string sceneName;


    void Update()
    {
        //string sceneName = "Space_Map3";
        if (transform.name == "Level1")
        {
            sceneName = "Space_Map3";
        }
        if (transform.name == "Level2")
        {
            sceneName = "Space_Map4";
        }
        if (transform.name == "Level3")
        {
            sceneName = "Space_Map5";
        }
        if (transform.name == "Level4")
        {
            sceneName = "Space_Map6";
        }
        if (transform.name == "Level5")
        {
            sceneName = "Space_Map7";
        }
        if (transform.name == "Level6")
        {
            sceneName = "Space_Map8";
        }			
        UpdateScore(sceneName);
    }

    void UpdateScore(string sceneName)
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore" + sceneName, 0).ToString();
        highScoreTime.text = PlayerPrefs.GetString("HighScore" + sceneName + "Time", "0:00:00");
    }
}
