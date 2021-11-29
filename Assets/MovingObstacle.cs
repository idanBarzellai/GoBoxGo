using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    Rigidbody rb;
    float force = 75f;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("ExpertMode") == 1)
            force *= 2;
        else
            force = 75f;
        rb = GetComponent<Rigidbody>();
       rb.AddForce(new Vector3(0, 0, -force), ForceMode.Impulse);
    }
}
