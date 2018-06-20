using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour {
    public float strength;
    public Transform WindBox;
    public Vector3 direction;
    public GameObject ball;

    public Rigidbody rb;

    void Start()
    {
        ball = GameObject.Find("Ball");
        rb = ball.GetComponent<Rigidbody>();
        WindBox = GameObject.Find("windArea").transform;
    }

    void Update()
    {
        direction = WindBox.forward;
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "WindArea")
        {
            rb.AddRelativeForce(WindBox.forward * strength);
            rb.useGravity = false;
        }
    }   

    void OnTriggerExit(Collider col)
    {
        rb.useGravity = true;
    }
}
