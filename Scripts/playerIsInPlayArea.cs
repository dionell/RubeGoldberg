using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerIsInPlayArea : MonoBehaviour {

    public bool playerIsInThePlayArea = false;

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.name == "Player")
        {
            playerIsInThePlayArea = true;
            Debug.Log("Player is in the play area");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.name == "Player")
        {
            playerIsInThePlayArea = false;
        }
    }
}
