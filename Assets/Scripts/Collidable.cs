using UnityEngine;

public class Collidable : MonoBehaviour
{
    public Player movement;
    public AudioSource audio;
    
    private void Start()
    {
        audio = GetComponent<AudioSource>();    
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag == "Obstacles")
        {
            movement.enabled = false ;
            audio.Play();
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
