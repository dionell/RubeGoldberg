using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour {

    public EnableGoal enableGoal;
    public Material[] material;
    public Renderer rend;

    public BoxCollider boxCollider;
    public CollectibleController collectibles;

    public BallReset ballReset;

    public bool levelComplete;
    

    void Start()
    {
        levelComplete = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

        boxCollider = GameObject.Find("GoalTrigger").GetComponent<BoxCollider>();
        collectibles = GameObject.Find("CollectibleController").GetComponent<CollectibleController>();
        ballReset = GameObject.Find("Ball").GetComponent<BallReset>();
    }

    void Update()
    {
        if(enableGoal.gameHasStarted == true && collectibles.gotAllCollectibles == true)
        {
            levelComplete = true;
            rend.sharedMaterial = material[0];
            //Debug.Log("goal is enabled");
        }
        else
        {
            levelComplete = false;
            rend.sharedMaterial = material[1];
            //Debug.Log("goal is not active");
        }
    }
}
