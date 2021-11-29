using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObstcale : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, -20f), ForceMode.Impulse);
    }
}
