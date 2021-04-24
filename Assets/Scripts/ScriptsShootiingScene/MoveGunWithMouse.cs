    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGunWithMouse : MonoBehaviour
{
    public float speedH;
    public float speedV;
    float yaw;
    float pitch;
    void Start()
    {
        
    }


    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw,0.0f);
    }
}
