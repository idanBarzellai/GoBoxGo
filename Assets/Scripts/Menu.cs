
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{

    public Toggle soundToggle;
    public Toggle vibrateToggle;
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
        speedDropdown.value = PlayerPrefs.GetInt("ExpertMode");
        speedDropdown.RefreshShownValue();
        PlayerPrefs.SetInt("ExpertMode", speedDropdown.value);
        SetSpeed(speedDropdown.value);
    }
    private void Update()
    {
        speedDropdown.value = PlayerPrefs.GetInt("ExpertMode");
        speedDropdown.RefreshShownValue();
        
        if (PlayerPrefs.GetInt("Vibrate") == 1)
            VibrateToggle(true);
        else
            VibrateToggle(false);

        if (PlayerPrefs.GetInt("Music") == 1)
            SoundToggle(true);
        else
            SoundToggle(false);
        
        for (int i = 0; i < levelNames.Length; i++)
        {
            if (PlayerPrefs.GetInt(levelNames[i]) == 1)
                PlayerPrefs.SetString("RecordLevel", levelNames[i]);            
        }
    }

    public void DeleteAllAchivements()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("RecordLevel", levelNames[0]);
        PlayerPrefs.SetInt("ExpertMode", speedDropdown.value);
        PlayerPrefs.SetInt("Music", 0);
        PlayerPrefs.SetInt("Vibrate", 0);
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

    public void SetSpeed(int speedIndex)
    {
        if (speedIndex == 0)
        {
            PlayerPrefs.SetInt("speed", 2500);
            PlayerPrefs.SetFloat("sidewaysSpeed", 50f);
        }
        else
        {
            PlayerPrefs.SetInt("speed", 3200);
            PlayerPrefs.SetFloat("sidewaysSpeed", 100f);
        }
        PlayerPrefs.SetInt("ExpertMode", speedIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
