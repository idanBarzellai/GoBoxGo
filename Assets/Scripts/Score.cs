using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;
    public TMP_Text highscore;
    string scenename;
    int highscoreInt = 0;
    private void Start()
    {
        scenename = SceneManager.GetActiveScene().name;
        highscoreInt = PlayerPrefs.GetInt(scenename + "highscore", highscoreInt);
        if (highscoreInt >= 500)
            highscoreInt = 0;
    }
    private void Update()
    {
        scoreText.text = "" + (int)player.position.z;
        highscore.text = "" + PlayerPrefs.GetInt(scenename + "highscore", highscoreInt);
        if (highscoreInt <= player.position.z)
        {
            highscoreInt = (int)player.position.z;
            if (highscoreInt >= 500)
                highscoreInt = 0;
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
