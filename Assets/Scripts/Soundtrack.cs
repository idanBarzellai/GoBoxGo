using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (GameObject.FindGameObjectsWithTag("Soundtrack") != null && GameObject.FindGameObjectsWithTag("Soundtrack").Length > 1)
            Destroy(GameObject.FindGameObjectsWithTag("Soundtrack")[1]);
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        PlayMusic();
    }
    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
}
