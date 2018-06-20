using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuManager : MonoBehaviour {

    public List<GameObject> objectList; //the icons on your controller
    public List<GameObject> objectPrefabList; //object to instantiate, and must match order of scene menu objects in heirarchy

    public int currentObject = 0; //current selection index number

	// Use this for initialization
	void Start () {
		foreach(Transform child in transform) //any child gameobject with a transform
        {
            objectList.Add(child.gameObject); //adds gameobject to the list 
        }
	}

    //when player swipes joystick to the left
    public void menuLeft()
    {
        objectList[currentObject].SetActive(false); //deactives current object
        currentObject--; //subtracts 1 to the index
        //if player swipes left but index is on 0
        if(currentObject < 0)
        {
            currentObject = objectList.Count - 1;
        }
        //reactivate new gameobject
        objectList[currentObject].SetActive(true);
    }

    //when player swipes joystick to the right
    public void menuRight()
    {
        objectList[currentObject].SetActive(false); //deactives current object
        currentObject++; //Adds 1 to the index
        //if player swipes right but index is on max
        if (currentObject > objectList.Count - 1)
        {
            currentObject = 0;
        }
        //reactivate new gameobject
        objectList[currentObject].SetActive(true);
    }

    public void spawnCurrentObject()
    {
        Instantiate(objectPrefabList[currentObject], objectList[currentObject].transform.position, objectList[currentObject].transform.rotation);
        objectList[currentObject].SetActive(false);
        objectList.RemoveAt(currentObject);
        objectPrefabList.RemoveAt(currentObject);
        currentObject = 0;

    }
    // Update is called once per frame
    void Update () {
		
	}
}
