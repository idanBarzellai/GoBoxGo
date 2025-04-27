using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Rigidbody rb;

    public int speed;
    public float sidewaySpeed = 50f;
    private float dirX;

    private void Update()
    {
        speed = PlayerPrefs.GetInt("speed");
        sidewaySpeed = PlayerPrefs.GetFloat("sidewaysSpeed");
        dirX = Input.acceleration.x * sidewaySpeed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -500, 500), transform.position.y, transform.position.z);
        if (SceneManager.GetActiveScene().name == "Level11") { speed = 0; }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, speed * Time.deltaTime);
        rb.velocity = new Vector3(dirX, 0, speed * Time.deltaTime);

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(500 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(-500 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (rb.position.y < -1 || rb.position.x > 8 || rb.position.x < -8)
            FindObjectOfType<GameManager>().EndGame();
    }
}
