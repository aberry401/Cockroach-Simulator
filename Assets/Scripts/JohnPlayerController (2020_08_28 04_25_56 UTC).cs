using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;

public class JohnPlayerController : MonoBehaviour
{
    public Transform[] points;
    public float zoomValue;
    public GameObject cam;
    public float speed;
    public Material myShader;
    public bool found;
    public float timeInterval, timeCount;


    private void Start()
    {
        zoomValue = 0;
        timeCount = 0 + timeInterval;
    }

    private void Update()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll > 0 || scroll < 0)
        {
            Debug.Log(scroll);
            zoomValue -= Input.mouseScrollDelta.y/100f;
            if (zoomValue > 1f)
                zoomValue = 1f;
            else if (zoomValue < 0f)
                zoomValue = 0f;
        }
        if (Time.time >= timeCount)
        {
            timeCount += timeInterval;
            if (found)
            {
                myShader.SetFloat("_spottedBool", 1);
                found = false;
            }
            else if (!found)
            {
                myShader.SetFloat("_spottedBool", 0);
                found = true;
            }
        }
        cam.transform.position = BezCurve();
    }

    private void LateUpdate()
    {

        transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);

    }




    private Vector3 BezCurve()
    {

        float zValue;
        float yValue;
        float xValue = points[0].position.x;

        //The location along the curve from 0 < t < 1

        float zoom = zoomValue;

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
