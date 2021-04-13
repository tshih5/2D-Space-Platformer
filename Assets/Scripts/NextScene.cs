using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    [SerializeField] private int nextLevel;

    void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.tag == "Player") {
            //update score based on time completing map
            Score s = GameObject.Find("Score").GetComponent<Score>();
            GameTimeScript gametime = GameObject.Find("GameTimeDisplay").GetComponent<GameTimeScript>();
            s.score += 40000 / gametime.GetTimeInSeconds(); //change this to modify score scaling with time completion **NOTE: POORLY BALANCED SCORING METHOD

            SceneManager.LoadScene(nextLevel);
		}
    }
}
