using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderController : MonoBehaviour {

    public bool ladderIsGrounded = false;
    public GameObject ladderCollider;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Floor")
        {
            ladderIsGrounded = true;
            Debug.Log("Ladder is grounded");
            ladderCollider.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Floor")
        {
            ladderIsGrounded = false;
            Debug.Log("Ladder is not on the ground");
            ladderCollider.SetActive(false);
        }
    }
}
