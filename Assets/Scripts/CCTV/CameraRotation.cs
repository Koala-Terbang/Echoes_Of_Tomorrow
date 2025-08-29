using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float zMin = -120f;   // leftmost angle
    public float zMax = -60f;    // rightmost angle
    public float turnSpeed = 20f; // degrees per second

    private bool goingRight = true;

    void Update()
    {
        float z = transform.localEulerAngles.z;
        if (z > 180f) z -= 360f;  // normalize 0..360 → -180..180

        if (goingRight)
        {
            z += turnSpeed * Time.deltaTime;
            if (z >= zMax)
            {
                z = zMax;
                goingRight = false;
            }
        }
        else
        {
            z -= turnSpeed * Time.deltaTime;
            if (z <= zMin)
            {
                z = zMin;
                goingRight = true;
            }
        }

        transform.localEulerAngles = new Vector3(0, 0, z);
    }
}
