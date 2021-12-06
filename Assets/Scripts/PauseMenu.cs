using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Toggle soundToggle;
    public Toggle vibrateToggle;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Vibrate") == 1)
            VibrateToggle(true);
        else if (PlayerPrefs.GetInt("Vibrate") == 0)
            VibrateToggle(false);
        else
            PlayerPrefs.SetInt("Vibrate", 1);

        if (PlayerPrefs.GetInt("Music") == 1)
            SoundToggle(true);
        else if (PlayerPrefs.GetInt("Music") == 0)
            SoundToggle(false);
        else
            PlayerPrefs.SetInt("Music", 1);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Vibrate") == 1)
            VibrateToggle(true);
        else
            VibrateToggle(false);

        if (PlayerPrefs.GetInt("Music") == 1)
            SoundToggle(true);
        else
            SoundToggle(false);
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
        if (soundOn)
        {
            PlayerPrefs.SetInt("Music", 1);
            soundToggle.isOn = true;
        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
            soundToggle.isOn = false;
        }
    }

    public void VibrateToggle(bool vibrateOn)
    {
        //vibartionBool.isVibrating = vibrateOn;
        if (vibrateOn)
        {
            PlayerPrefs.SetInt("Vibrate", 1);
            vibrateToggle.isOn = true;
        }
        else
        {
            PlayerPrefs.SetInt("Vibrate", 0);
            vibrateToggle.isOn = false;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
