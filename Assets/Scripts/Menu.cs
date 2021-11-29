
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public VibrationBool vibarte;
    public TMP_Dropdown speedDropdown;
    private string[] levelNames = new string[10];
    private void Awake()
    {
       
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        
        for (int i = 0; i < 9; i++)
        {
            int j = i + 1;
            levelNames[i] = "Level0" + j;
        }
        levelNames[9] = "Level10";
        PlayerPrefs.SetString("RecordLevel", levelNames[0]);
    }

    private void Start()
    {
        speedDropdown.value = PlayerPrefs.GetInt("ExpertMode");
        speedDropdown.RefreshShownValue();
        PlayerPrefs.SetInt("ExpertMode", speedDropdown.value);
        SetSpeed(speedDropdown.value);
    }
    private void Update()
    {
        speedDropdown.value = PlayerPrefs.GetInt("ExpertMode");
        speedDropdown.RefreshShownValue();
        VibrateToggle(vibarte.isVibrating);
        for (int i = 0; i < levelNames.Length; i++)
        {
            if (PlayerPrefs.GetInt(levelNames[i]) == 1)
            {
                PlayerPrefs.SetString("RecordLevel", levelNames[i]);
            }
        }
    }

    public void DeleteAllAchivements()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("RecordLevel", levelNames[0]);
        PlayerPrefs.SetInt("ExpertMode", speedDropdown.value);
        SetSpeed(speedDropdown.value);
        for (int i = 0; i < levelNames.Length; i++)
        {
            PlayerPrefs.SetInt(levelNames[i], 0);
        }
    }
    public void GameStart()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("RecordLevel"));
    }
    public void ZenMode()
    {
        SceneManager.LoadScene("Level11");
    }
    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("Menu 1-levelSelect");
    }
    public void SoundToggle(bool soundOn)
    {
        AudioListener.pause = !soundOn;
    }

    public void VibrateToggle(bool vibrateOn)
    {
        vibarte.isVibrating = vibrateOn;
    }

    public void SetSpeed(int speedIndex)
    {
        if (speedIndex == 0)
        {
            PlayerPrefs.SetInt("speed", 2500);
            PlayerPrefs.SetFloat("sidewaysSpeed", 50f);
        }
        else
        {
            PlayerPrefs.SetInt("speed", 3500);
            PlayerPrefs.SetFloat("sidewaysSpeed", 200f);
        }
        PlayerPrefs.SetInt("ExpertMode", speedIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
