using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public playerIsInPlayArea playArea;
    public BallReset ballReset;
    
    void Update()
    {
        if(playArea.playerIsInThePlayArea == true)
        {
            ballReset.BallResetPosition();
        }
    }
}
