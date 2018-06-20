using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMultiplier : MonoBehaviour {

    public float speedMultiplier;
    public GameObject ball;
    public Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
        rigidBody = ball.GetComponent<Rigidbody>();
    }

    void multiplySpeed()
    {
        rigidBody.AddForce(rigidBody.velocity * speedMultiplier, ForceMode.Impulse);

    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.name == "Ball")
        {
            Debug.Log("multiply speed of ball");
            multiplySpeed();
        }
    }
}
