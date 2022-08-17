using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBox : MonoBehaviour
{
    float xSpeed = 0.0f;
    float ySpeed = 0.0f;
    float zSpeed = 0.0f;
    public bool RotateMe = false;

    void Update()
    {

        if (RotateMe)
        {
            ySpeed = 40;
        }
        else
        {
            ySpeed = 0;
        }
        transform.Rotate(
            xSpeed * Time.deltaTime,
            ySpeed * Time.deltaTime,
            zSpeed * Time.deltaTime
        );
    }

    public void ChangeBool()
    {
        RotateMe = !RotateMe;
    }
}
