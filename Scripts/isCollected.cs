using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCollected : MonoBehaviour {

    public CollectibleController collectible;

    void Start()
    {
        collectible = GetComponentInParent<CollectibleController>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ball")
        {
            gameObject.SetActive(false);
            collectible.collectiblesCount--;
            //Debug.Log(collectible.collectiblesCount);
        }
    }
}
