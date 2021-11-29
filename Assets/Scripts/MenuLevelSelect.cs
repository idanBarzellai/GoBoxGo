
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelSelect : MonoBehaviour
{
    public GameObject[] levels;
    

    private void Update()
    {
        foreach (GameObject level in levels)
        {
            if (PlayerPrefs.GetInt(level.name) == 1)
                level.SetActive(true);
        }
    }
    public void PlayLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
 
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
   
}
