using UnityEngine;

public class Collidable : MonoBehaviour
{
    public Player movement;
    public AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag == "Obstacles")
        {
            movement.enabled = false ;
            audioSource.Play();
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
