using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HeadsetManager : MonoBehaviour {

    public GameObject viveRig;
    public GameObject oculusRig;

    private bool hmdChosen;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (!hmdChosen)
        {
            if (XRDevice.model == "Vive MV")
            {
                viveRig.SetActive(true);
                oculusRig.SetActive(false);
                hmdChosen = true;
            }
            else if (XRDevice.model == "Oculus Rift CV1")
            {
                viveRig.SetActive(false);
                oculusRig.SetActive(true);
                hmdChosen = true;
            }
        }
        if (!XRDevice.isPresent){
            hmdChosen = false;
        }
	}
}
