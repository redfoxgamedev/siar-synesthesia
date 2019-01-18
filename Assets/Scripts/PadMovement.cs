using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadMovement : MonoBehaviour {

    public static string TAG = "VR: ";

    public Transform playerEyes;
    public Transform player;
    public Renderer debugObject;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (OVRInput.Get(OVRInput.Touch.PrimaryTouchpad) || (Input.GetKey(KeyCode.R))){
            //debugObject.enabled = true;
            Vector2 padDirection = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad); //already normalized
            //padDirection = Vector2.up;

            if (padDirection.y >=0.5f){
                //general moving forward
                Vector3 currentDirection = Vector3.ProjectOnPlane(playerEyes.transform.forward, Vector3.up).normalized;
                player.transform.Translate(currentDirection * 1 * Time.deltaTime, Space.World);
            }


            //Vector2 padForward = Vector2.up; //normalized

            //Vector2 padDifference = padForward - padDirection; //not normalized?

            //Debug.Log(TAG + "Pad direction is "+padDirection);

            //Vector3 currentDirection = Vector3.ProjectOnPlane(playerEyes.transform.forward, Vector3.up);

            //Debug.DrawRay(playerEyes.transform.position, currentDirection, Color.blue);
            

            //Debug.Log(TAG + "Current player direction is " + currentDirection);
            //Vector3 padDifferenceWorld = new Vector3(padDifference.x, 0, padDifference.y);

            //Debug.Log(TAG + "World pad direction is " + padDifferenceWorld);

            //Vector3 resultMovementDirection = (currentDirection + padDifferenceWorld).normalized;

            //Debug.DrawRay(playerEyes.transform.position, resultMovementDirection, Color.green);

            //Debug.Log(TAG + "Result movement is " + resultMovementDirection);
            
            //player.transform.Translate(resultMovementDirection * 1 * Time.deltaTime, Space.World);

        }

        if (OVRInput.GetUp(OVRInput.Touch.PrimaryTouchpad)){
            debugObject.enabled = false;
        }

	}
}
