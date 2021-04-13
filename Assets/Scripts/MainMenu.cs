using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public AudioMixer audioMixer;
	public Slider volumeSlider;
	public Dropdown graphicsDropdown;
	public Dropdown resolutionDropdown;
	public Toggle fullscreenToggle;
	
	Resolution[] resolutions;
	
	private void Start() {
		// These three lines watch for value changes in the UI
		volumeSlider.onValueChanged.AddListener(SetVolume);
		graphicsDropdown.onValueChanged.AddListener(SetQuality);
		resolutionDropdown.onValueChanged.AddListener(SetResolution);
		
		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();
		List<string> options = new List<string>();
		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) {
			string option = resolutions[i].width + "x" + resolutions[i].height;
			options.Add(option);
			
			if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) {
				currentResolutionIndex = i;
			}
		}
		
		/* This makes sure the resolution of the game is synced with the settings, 
		even after switching scenes */
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
		
		/* This makes sure the graphic quality stays the same, 
		even after switching scenes */
		graphicsDropdown.value = QualitySettings.GetQualityLevel();
		graphicsDropdown.RefreshShownValue();
		
		// This makes sure the volume and the slider are saved, even after switching scenes
		volumeSlider.value = PlayerPrefs.GetFloat("volume", volumeSlider.maxValue);
		
		// This makes sure the toggle for fullscreen is remembered and accurate
		if (Screen.fullScreen) {
			fullscreenToggle.isOn = true;
		}
		else {
			fullscreenToggle.isOn = false;
		}
	}
	
	public void SetFullscreen(bool isFullscreen) {
		Screen.fullScreen = isFullscreen;
	}
	
	public void SetQuality(int qualityIndex) {
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void SetResolution(int resolutionIndex) {
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}
	
	public void SetVolume(float targetVolume) {
		audioMixer.SetFloat("volume", Mathf.Log10(targetVolume) * 20f);
		// Save volume to player preferences
		PlayerPrefs.SetFloat("volume", targetVolume);
		Debug.Log(targetVolume);
	}
	
	public void PlayGame() {
        //i changed this function commented it out and using a different loadscene call
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Level_Selector");
	}
	
	public void QuitGame() {
		Debug.Log("Quit!");
		Application.Quit();
	}
}
