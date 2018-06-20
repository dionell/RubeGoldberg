using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteraction : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    public float throwForce = 1.5f;
    
    //Swipe
    public float swipeSum;
    public float touchLast;
    public float touchCurrent;
    public float distance;
    public bool hasSwipedUp;
    public bool hasSwipedDown;
    public ObjectMenuManager objectMenuManager;

	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //sets touchLast to 0 correctly
            touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y;
        }
        /*
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) //if player uses the joystick/touchpad
        {

            touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y; //access the y horizontal value of the joystick/touchpad
            distance = touchCurrent - touchLast;
            touchLast = touchCurrent;
            swipeSum += distance;

            if (!hasSwipedRight)
            {
                if (swipeSum >= 0.5f)
                {
                    swipeSum = 0;
                    SwipedRight();
                    hasSwipedRight = true;
                    hasSwipedLeft = false;
                }
            }
            else if (!hasSwipedLeft)
            {
                if (swipeSum <= 0.5f)
                {
                    swipeSum = 0;
                    SwipedLeft();
                    hasSwipedRight = false;
                    hasSwipedLeft = true;
                }
            }
            */
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)) //if player uses the joystick/touchpad
        {

            Vector2 touchpad = (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));


            if (touchpad.y >= 0.5f && !hasSwipedDown)
            {
                print("Moving Up");
                swipeSum = 0;
                SwipedRight();
                hasSwipedDown = true;
                hasSwipedUp = false;
            }

            else if (touchpad.y <= -0.5f && !hasSwipedUp)
            {
                print("Moving Down");
                swipeSum = 0;
                SwipedLeft();
                hasSwipedDown = false;
                hasSwipedUp = true;
            }
            /*
            touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y; //access the y horizontal value of the joystick/touchpad
            distance = touchCurrent - touchLast;
            touchLast = touchCurrent;
            swipeSum += distance;

            if (!hasSwipedRight)
            {
                if (swipeSum >= 0.5f)
                {
                }
            }
            else if (!hasSwipedLeft)
            {
                if (swipeSum <= 0.5f)
                {
                }
            }
            */

        }

        //when player releases joystick/touchpad
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            swipeSum = 0;
            touchCurrent = 0;
            touchLast = 0;
            hasSwipedUp = false;
            hasSwipedDown = false;
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
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
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip)) //release
            {
                ThrowObject(col);
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) //hold down
            {
                GrabObject(col);
            }
        }

    }
    void GrabObject(Collider coli)
    {
        coli.transform.SetParent(gameObject.transform); //turns grabbed object into a child of the controller
        device.TriggerHapticPulse(2000); //vibration
        Rigidbody rigidbody = coli.GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        //Debug.Log("Touching trigger on an object");
        /*if (coli.gameObject.name == "Ball" || coli.gameObject.tag == "Trampoline")
        {
            rigidbody.isKinematic = true;
        }*/
    }

    void ThrowObject(Collider coli)
    {
        coli.transform.SetParent(null); //unparents
        Rigidbody rigidbody = coli.GetComponent<Rigidbody>();
        rigidbody.velocity = device.velocity * throwForce; //velocity based on controller's movement
        rigidbody.angularVelocity = device.angularVelocity;
        if (coli.gameObject.tag == "ObjectsWithMeshColliders")
        {
            rigidbody.isKinematic = true;
        }
        else
        {
            rigidbody.isKinematic = false;

        }
        //Debug.Log("Trigger released");
    }

}
