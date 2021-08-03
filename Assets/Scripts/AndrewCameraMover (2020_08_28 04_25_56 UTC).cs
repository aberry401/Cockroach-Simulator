using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Andrew Berry
public class AndrewCameraMover : MonoBehaviour
{
    public Transform[] bezPoints;
    public Transform player;
    public Transform dest;
    public Transform start;
    private bool move;
    private string playerDirection;
    private bool third = true;
    private float time = 0;
    private Vector3 left = new Vector3(0, -1, 0);
    private Vector3 right = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (!move)
        {
            if (third)
            {
                transform.position = start.position;
            }
            else
            {
                transform.position = dest.position;
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (move)
        {
            if(playerDirection == "forwards")
            {
                player.GetComponent<AndrewPlayerController>().ToggleHoriz(true);
                if (time < 1)
                {
                    time += Time.deltaTime;
                    if (time > 1)
                    {
                        time = 1;
                    }
                    transform.position = BezierCurve();
                    transform.LookAt(player);
                }
                else
                {
                    move = false;
                    third = false;
                }
            }
            if(playerDirection == "backwards")
            {
                player.GetComponent<AndrewPlayerController>().ToggleHoriz(false);
                if (time > 0)
                {
                    time -= Time.deltaTime;
                    if (time < 0)
                    {
                        time = 0;
                    }
                    transform.position = BezierCurve();
                    transform.LookAt(player);
                }
                else
                {
                    move = false;
                    third = true;
                    transform.rotation = start.rotation;
                }
            }
        }
    }

    public void Move(string dir)
    {
        playerDirection = dir;
        move = true;
    }

    private Vector3 BezierCurve()
    {
        float xVal;
        float yVal = transform.position.y;
        float zVal;

        zVal = (bezPoints[2].position.z - bezPoints[0].position.z) * time + bezPoints[0].position.z;

        double temp = Math.Pow(1 - time, 2) * bezPoints[0].position.x +
                 2 * (1 - time) * time * bezPoints[1].position.x +
                 Math.Pow(time, 2) * bezPoints[2].position.x;

        xVal = (float)temp;

        return new Vector3(xVal, yVal, zVal);
    }
}
