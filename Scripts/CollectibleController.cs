using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour {

    public int collectiblesCount;
    public GameObject[] collectibles;
    public EnableGoal enableGoal;
    public bool gotAllCollectibles;

    //if collectiblescount is equals to zero, activate goal. 
    //if ball touches the ground, reactivate collectibles.

    void Start()
    {
        collectibles = GameObject.FindGameObjectsWithTag("Collectibles");
        collectiblesCount = collectibles.Length;
        gotAllCollectibles = false;
    }

    void Update()
    {
        if(collectiblesCount <= 0)
        {
            gotAllCollectibles = true;
        }
        else
        {
            gotAllCollectibles = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
    }

    public void collectiblesReset()
    {
        foreach(GameObject go in collectibles)
        {
            collectiblesCount = collectibles.Length;
            go.SetActive(true);
        }
    }
}
