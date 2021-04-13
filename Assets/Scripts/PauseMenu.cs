using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	
	public MonoBehaviour[] disabledOnes; //Scripts to Disable when Paused

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume();
			}
			else {
				Pause();
			}
		}
    }
	
	public void Resume() {
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		for (int i = 0; i < disabledOnes.Length; i++) {
			if (disabledOnes[i].enabled == false) {
				disabledOnes[i].enabled = true;
			}
		}
		GameIsPaused = false;
	}
	
	void Pause() {
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		for (int i = 0; i < disabledOnes.Length; i++) {
			if (disabledOnes[i].enabled == true) {
				disabledOnes[i].enabled = false;
			}
		}		
		GameIsPaused = true;
	}
	
	public void LoadMenu() {
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}
	
	public void QuitGame() {
		Debug.Log("Quitting game..");
		Application.Quit();
	}
}
