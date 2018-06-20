using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceAway : MonoBehaviour
{
    public float force;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Ball")
        {
            Vector3 direction = transform.forward;
            direction = direction.normalized;
            col.GetComponent<Rigidbody>().AddForce(direction * force);
        }

    }
}
