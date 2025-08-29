using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float zRight;
    public float zLeft;
    public float slowPanning = 2.5f;
    public float pause = 0.2f;

    float timer = 0f;
    bool goingRight = true;
    float currentZ;

    void Start()
    {
        currentZ = GetSignedZ();
    }

    void Update()
    {
        if (timer < 0f)
        {
            timer += Time.deltaTime;
            return;
        }

        float t = Mathf.Clamp01(timer / Mathf.Max(0.0001f, slowPanning));
        float targetA = goingRight ? zRight  : zLeft;
        float targetB = goingRight ? zLeft : zRight;

        currentZ = Mathf.Lerp(targetA, targetB, t);
        SetSignedZ(currentZ);

        timer += Time.deltaTime;

        if (timer >= slowPanning)
        {
            goingRight = !goingRight;
            timer = -pause;
        }
    }
    float GetSignedZ()
    {
        float z = transform.localEulerAngles.z;
        if (z > 180f) z -= 360f;
        return z;
    }

    void SetSignedZ(float zSigned)
    {
        float z = zSigned;
        if (z < 0f) z += 360f;
        var e = transform.localEulerAngles;
        e.z = z;
        transform.localEulerAngles = e;
    }
}
