using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcTeleport : MonoBehaviour
{
    public Transform controller;
    public Transform player;

    public Transform objectDebug;

    private bool isTeleportBegin;
    private Vector3 teleportTarget;

    public LineRenderer visualArc;

    private int lineSegments = 20;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKey(KeyCode.W)){
            //begin teleport
            isTeleportBegin = true;
            visualArc.enabled = true;
            //teleport planning action
            planTeleport();
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) && isTeleportBegin){
            //teleport! (if it began)
            isTeleportBegin = false;
            visualArc.enabled = false;

            //teleport action
            player.transform.position = teleportTarget + Vector3.up * 1.7f;
        }
    }

    private void planTeleport()
    {
       
        //Vector3 localPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.Active);
        //Debug.Log(localPos);
        //objectDebug.position = controller.position+controller.forward*1.5f;
        Vector3 beginPoint = controller.position;
       // Debug.Log("Controller pos " + beginPoint);
        Vector3 endPoint = beginPoint + controller.forward * 20 - controller.up * 5;
        Vector3 controlPoint = Vector3.Lerp(beginPoint, endPoint, 0.5f) + controller.up * 10;

        float sampleStep = 1.0f / (lineSegments-1);
        float currentStep = 0f;

        Vector3[] samplePoints = new Vector3[lineSegments];

        for (int i = 0; i < lineSegments; i++){
            samplePoints[i] = sampleCurve(beginPoint, endPoint, controlPoint, currentStep);
            currentStep += sampleStep;
            //Debug.Log("Step " + i);
        }
        visualArc.positionCount = lineSegments;
        visualArc.SetPositions(samplePoints);

        RaycastHit hitInfo;
        for (int i = 0; i < lineSegments-1; i++){
            Vector3 pointBegin = samplePoints[i];
            Vector3 pointEnd = samplePoints[i + 1];

            if (Physics.Linecast(pointBegin, pointEnd, out hitInfo)){
                Vector3 hitPosition = hitInfo.point;
                objectDebug.position = hitPosition;
                teleportTarget = hitPosition;
                break;
            }
        }

    }

    Vector3 sampleCurve(Vector3 start, Vector3 end, Vector3 control, float t){
        // Interpolate along line S0: control - start;
        Vector3 Q0 = Vector3.Lerp(start, control, t);
        // Interpolate along line S1: S1 = end - control;
        Vector3 Q1 = Vector3.Lerp(control, end, t);
        // Interpolate along line S2: Q1 - Q0
        Vector3 Q2 = Vector3.Lerp(Q0, Q1, t);
        return Q2; // Q2 is a point on the curve at time t
    }
}
