using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BezCurveMovement : MonoBehaviour
{
    public Transform[] points;
    public int zoomValue;
    public GameObject theCamera;
    private Vector3 cameraLoc;


    private void Start()
    {
        zoomValue = 0;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && zoomValue < 100)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                zoomValue += 10;
            else
                zoomValue += 1;
            if (zoomValue > 100)
                zoomValue = 100;
        }
        theCamera.transform.position = BezCurve();
    }



    private void InceaseZoom()
    {

    }

    /// <summary>
    /// Returns the position between 3 points for smooth interpolation
    /// 
    /// </summary>
    private Vector3 BezCurve()
    {

        float zValue;
        float yValue;
        float xValue = transform.position.x;

        //The location along the curve from 0 < t < 1
        float zoom = zoomValue / 100f;

        //calculating linear formula for z
        zValue = (points[2].position.z - points[0].position.z) * zoom + points[0].position.z;

        //The Actual Bezier curve part I kind of just wrote out a formula I found online
        //B(t) = ((1-t)^2)*P[0] + 2*(1-t)*t*P[1] + (t^2)*P[2] 
        //and plugged in the values
        double temp = Math.Pow(1 - zoom, 2) * points[0].position.y + 
                 2 * (1 - zoom) * zoom * points[1].position.y +
                 Math.Pow(zoom, 2) * points[2].position.y;

        yValue = (float)temp;


        return new Vector3(xValue, yValue, zValue);        
    }



}
