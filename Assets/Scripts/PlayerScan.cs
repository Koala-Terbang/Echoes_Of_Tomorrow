using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScan : MonoBehaviour
{
    public float scanRadius = 6f;
    public LayerMask droneMask;
    public float scanCooldown = 2f;
    float nextScanTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= nextScanTime)
        {
            DoScan();
            nextScanTime = Time.time + scanCooldown;
        }
    }

    void DoScan()
    {
        Vector2 origin = transform.position;
        var hits = Physics2D.OverlapCircleAll(origin, scanRadius, droneMask);

        for (int i = 0; i < hits.Length; i++)
        {
            var drone = hits[i].GetComponentInParent<DronePatrol>() ?? hits[i].GetComponent<DronePatrol>();
            if (drone) drone.Reveal();
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }
}
