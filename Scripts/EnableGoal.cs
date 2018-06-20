using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGoal : MonoBehaviour {

    public bool gameHasStarted;
    public Material[] material;
    public Renderer rend;
    public CollectibleController collectibles;

    // Use this for initialization
    void Start () {
        gameHasStarted = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ball")
        {
            GoalIsEnabled();
        }
    }

    public void GoalIsEnabled()
    {
        gameHasStarted = true;

    }

    // Update is called once per frame
    void Update () {
		if(gameHasStarted == true)
        {
            rend.sharedMaterial = material[0];
            //Debug.Log("ball has entered the start zone");
        }
        else
        {
            rend.sharedMaterial = material[1];
            gameHasStarted = false;
            //Debug.Log("ball has not yet entered the start zone");
        }
	}

}
