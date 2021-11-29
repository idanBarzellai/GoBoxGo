using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameManager gm;
    public AudioSource audioWin;
    private void Start()
    {
        audioWin = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {   if (other.tag == "Player")
        {
            gm.CompleteLevel();
            audioWin.Play();
        }
    }
}
