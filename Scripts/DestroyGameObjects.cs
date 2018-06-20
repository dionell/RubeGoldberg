using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjects : MonoBehaviour {

    public GameObject resetPosition;
    public Rigidbody rigidBody;

    void Awake()
    {
        resetPosition = GameObject.Find("ObjectResetPosition");
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "BoundingBox")
        {
            ObjectResetPosition();
        }
    }

    public void ObjectResetPosition()
    {
        transform.SetParent(null);
        transform.position = resetPosition.transform.position;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }
}
