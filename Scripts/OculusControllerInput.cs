using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusControllerInput : MonoBehaviour
{

    //platform bounding boxes
    public OculusHandInteraction oculusHandInteraction;

    // Teleporter
    private LineRenderer laser;
    public GameObject teleportAimerObject;
    public Material teleportAimerObjectMat;
    public Vector3 teleportLocation;
    public GameObject player;
    public LayerMask laserMask;
    public static float yNudgeAmount = .25f; // specific to teleportAimerObject height
    private static readonly Vector3 yNudgeVector = new Vector3(0f, yNudgeAmount, 0f);
    public bool isGrounded;

    //disable ball's rigidbody when player is outside the platform
    public Rigidbody rigidBody;


    // Use this for initialization
    void Start()
    {
        teleportAimerObjectMat = teleportAimerObject.GetComponent<Renderer>().material;
        laser = GetComponentInChildren<LineRenderer>();
        isGrounded = false;
    }

    void setLaserStart(Vector3 startPos)
    {
        laser.SetPosition(0, startPos);
    }

    void setLaserEnd(Vector3 endPos)
    {
        laser.SetPosition(1, endPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) //oculus right trigger
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 40, laserMask))
            {
                if (!teleportAimerObject.activeSelf)
                {
                    laser.gameObject.SetActive(true);
                    teleportAimerObject.SetActive(true);
                }

                if (hit.collider.tag == "Ground" || hit.collider.tag == "Platform")
                {
                    isGrounded = true;
                    teleportAimerObjectMat.color = Color.green;
                }
                else
                {
                    isGrounded = false;
                    teleportAimerObjectMat.color = Color.red;
                    //laser.gameObject.SetActive(false);
                    //teleportAimerObject.SetActive(false);

                }

                setLaserStart(gameObject.transform.position);
                teleportLocation = hit.point;
            }
            /*
            else
            {
                teleportLocation = transform.position + 15 * transform.forward;
                RaycastHit groundRay;
                if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 17, laserMask))
                {
                    teleportLocation.y = groundRay.point.y;
                }
            }*/
            setLaserEnd(teleportLocation);
            // aimer
            teleportAimerObject.transform.position = teleportLocation + yNudgeVector;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) && isGrounded == true)
        {
            laser.gameObject.SetActive(false);
            teleportAimerObject.SetActive(false);
            player.transform.position = teleportLocation;
        }
        else if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) && isGrounded == false)
        {
            laser.gameObject.SetActive(false);
            teleportAimerObject.SetActive(false);

        }
    }
}