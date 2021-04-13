using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Level_01()
    {
        SceneManager.LoadScene("Space_Map3");
    }

    public void Level_02()
    {
        SceneManager.LoadScene("Space_Map4");
    }

    public void Level_03()
    {
        SceneManager.LoadScene("Space_Map5");
    }

    public void Level_04()
    {
        SceneManager.LoadScene("Space_Map6");
    }

    public void Level_05()
    {
        SceneManager.LoadScene("Space_Map7");
    }

    public void Level_06()
    {
        SceneManager.LoadScene("Space_Map8");
    }
}
