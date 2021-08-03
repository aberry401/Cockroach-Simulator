using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Written by Noah Johanson

public class NoahBezCurve : MonoBehaviour
{
    public Transform[] points;
    public int depth;
    public GameObject theCamera;
    public GameObject camPosStart;
    private bool rev;

   
    void Start()
    {
        depth = 0;
        rev = false;
        //theCamera.transform.position = camPosStart.transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            rev = !rev;
        }
        /*if (Input.GetKey(KeyCode.DownArrow) && depth < 100)
        {
            depth += 1;
            if (depth > 100)
                depth = 100;
        }
        if (Input.GetKey(KeyCode.UpArrow) && depth > 1)
        {
            depth -= 1;
            if (depth < 0)
                depth = 0;
        }
        theCamera.transform.position = BezCurve1();*/
        if (rev == false)
        {
            if (Input.GetKey(KeyCode.DownArrow) && depth < 100)
            {
                depth += 1;
                if (depth > 100)
                    depth = 100;
            }
            if (Input.GetKey(KeyCode.UpArrow) && depth > 1)
            {
                depth -= 1;
                if (depth < 0)
                    depth = 0;
            }
            theCamera.transform.position = BezCurve1();
        }
        else if(rev)
        {
            if (Input.GetKey(KeyCode.RightArrow) && depth < 100)
            {
                depth += 1;
                if (depth > 100)
                    depth = 100;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && depth > 1)
            {
                depth -= 1;
                if (depth < 0)
                    depth = 0;
            }
            theCamera.transform.position = BezCurve2();
        }
        Debug.Log(depth);
    }

    private Vector3 BezCurve1()
    {

        float zValue;
        float yValue;
        float xValue = transform.position.x;

        float zoom = depth / 100f;

        zValue = (points[2].position.z - points[0].position.z) * zoom + points[0].position.z;

        double temp = Math.Pow(1 - zoom, 2) * points[0].position.y +
                 2 * (1 - zoom) * zoom * points[1].position.y +
                 Math.Pow(zoom, 2) * points[2].position.y;

        yValue = (float)temp;


        return new Vector3(xValue, yValue, zValue);
    }

    private Vector3 BezCurve2()
    {
        float zValue;
        float yValue = camPosStart.transform.position.y;
        float xValue;

        float zoom = depth / 100f;

        zValue = (points[5].position.z - points[3].position.z) * zoom + points[3].position.z;

        double temp = Math.Pow(1 - zoom, 2) * points[3].position.x +
                 2 * (1 - zoom) * zoom * points[4].position.x +
                 Math.Pow(zoom, 2) * points[5].position.x;

        xValue = (float)temp;

        return new Vector3(xValue, yValue, zValue);
    }
}
