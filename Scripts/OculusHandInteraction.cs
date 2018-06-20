using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusHandInteraction : MonoBehaviour {
    public float throwForce = 1.5f;

    private OVRInput.Controller thisController;
    public bool leftHand;
    //Swipe
    public float swipeSum;
    public float touchLast;
    public float touchCurrent;
    public float distance;
    public bool hasSwipedLeft;
    public bool hasSwipedRight;
    public ObjectMenuManager objectMenuManager;
    public float menuStickY;
    public bool menuIsSwipable;

    public bool isHoldingAnObject;

	// Use this for initialization
	void Start ()
    {
        isHoldingAnObject = false;
        if (leftHand)
        {
            thisController = OVRInput.Controller.LTouch;
        }
        else
        {
            thisController = OVRInput.Controller.RTouch;
        }
    }

    // Update is called once per frame
    void Update () {

        if (!leftHand) //if player uses the joystick/touchpad
        {
            menuStickY = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick,
                 thisController).y;

            if (menuStickY < 0.45f && menuStickY > -0.45f)
            {
                menuIsSwipable = true;
            }
            if (menuIsSwipable)
            {
                if (menuStickY >= 0.45f)
                {
                    //fire function that looks at menuList,
                    //disables current item, and enables next item
                    SwipedLeft();
                    menuIsSwipable = false;
                }
                else if (menuStickY <= -0.45f)
                {
                    SwipedRight();
                    menuIsSwipable = false;
                }
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick, thisController))
        {
            spawnObject();
        }
        
    }

    void spawnObject()
    {
        objectMenuManager.spawnCurrentObject();
    }

    void SwipedLeft()
    {
        objectMenuManager.menuLeft();
        Debug.Log("SwipedLeft");
    }

    void SwipedRight()
    {
        objectMenuManager.menuRight();
        Debug.Log("SwipedRight");
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Throwable") || col.gameObject.tag == "ObjectsWithMeshColliders")
        {
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
            {
                ThrowObject(col);
            }
        }
    }

    void ThrowObject(Collider coli)
    {
        //coli.transform.SetParent(null); //unparents
        Rigidbody rigidbody = coli.GetComponent<Rigidbody>();
        rigidbody.velocity = OVRInput.GetLocalControllerVelocity(thisController) * throwForce; //velocity based on controller's movement
        rigidbody.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(thisController) * throwForce;

        //Debug.Log("Trigger released");

        if (coli.gameObject.tag == "ObjectsWithMeshColliders")
        {
            rigidbody.isKinematic = true;
        }
        else
        {
            rigidbody.isKinematic = false;

        }
    }
}
