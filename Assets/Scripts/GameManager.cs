using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public GameObject completeLevelUI;
    public AudioSource audioFail;
    private VibrationBool vibartionBool;


    private void Awake()
    {
        Time.timeScale = 1f;
    }
    private void Start()
    {
        audioFail = GetComponent<AudioSource>();
        vibartionBool = FindObjectOfType<VibrationBool>();
    }
    
    public void EndGame()
    {
        if(!gameEnded)
        {
            if (vibartionBool.isVibrating)
                Handheld.Vibrate();
            gameEnded = true;
            audioFail.Play();
            Invoke("Restart", 0.5f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    
}
