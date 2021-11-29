using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private Toggle vibrate;
    private VibrationBool vibartionBool;

    private void Awake()
    {
        vibartionBool = FindObjectOfType<VibrationBool>();
        vibrate = GameObject.FindGameObjectWithTag("Vibration").GetComponent<Toggle>(); 
    }

    private void Update()
    {
        vibrate.isOn = vibartionBool.isVibrating;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SoundToggle(bool soundOn)
    {
        AudioListener.pause = !soundOn;
    }

    public void VibrateToggle(bool vibrateOn)
    {
        vibartionBool.isVibrating = vibrateOn;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
