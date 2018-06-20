using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour {

    public GameObject ballResetPosition;
    public Rigidbody rigidBody;
    public BallController ballController;
    public EnableGoal enableGoal;

    public CollectibleController collectibles;
    
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            BallResetPosition();
        }
    }

    public void BallResetPosition()
    {
        enableGoal.gameHasStarted = false;
        collectibles.collectiblesReset();
        transform.SetParent(null);
        transform.position = ballResetPosition.transform.position;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }
}
