
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndlessScore : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;
    public TMP_Text highscore;
    string scenename;
    int highscoreInt = 0;
    float timeCounter;
    private void Start()
    {
        scenename = SceneManager.GetActiveScene().name;
        highscoreInt = PlayerPrefs.GetInt(scenename + "highscore", highscoreInt);
        timeCounter = Time.time;
    }
    private void Update()
    {
        scoreText.text = "" +(Time.time - timeCounter).ToString("F2");
        highscore.text = "" + PlayerPrefs.GetInt(scenename + "highscore", highscoreInt);
        if (highscoreInt <= (int)(Time.time - timeCounter))
        {
            highscoreInt = (int)(Time.time - timeCounter);
            PlayerPrefs.SetInt(scenename + "highscore", highscoreInt);
            PlayerPrefs.Save();
        }
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt(scenename + "highscore", highscoreInt);
        PlayerPrefs.Save();
    }
}
