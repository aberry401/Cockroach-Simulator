using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject pos;
    public GameObject focus;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(focus.transform);
        transform.position = pos.transform.position;

    }
}
