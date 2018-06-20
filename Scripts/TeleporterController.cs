using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour {

    public GameObject ball;
    public GameObject destination;

    void Start()
    {
        ball = GameObject.Find("Ball");
        destination = GameObject.Find("TeleportLocation");
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Ball")
        {
            ball.transform.position = destination.transform.position;
        }
    }
}
