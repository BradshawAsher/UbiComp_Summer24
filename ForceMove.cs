using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ForceMove : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0,0,thrust,ForceMode.Force);
        float zPosition = transform.position.z;
        if (zPosition <= 6.0f){
            thrust = 0.0f;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}