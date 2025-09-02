using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScan : MonoBehaviour
{
    public float scanRadius = 6f;
    public LayerMask droneMask;
    public float scanCooldown = 2f;
    float nextScanTime = 0f;
    public Animator anim;
    public ScanCDUI scanUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= nextScanTime)
        {
            DoScan();
            scanUI.Begin(scanCooldown);
            nextScanTime = Time.time + scanCooldown;
        }
    }
    void DoScan()
    {
        anim.Play("Scanning");
        Vector2 origin = transform.position;
        var hits = Physics2D.OverlapCircleAll(origin, scanRadius, droneMask);

        for (int i = 0; i < hits.Length; i++)
        {
            var drone = hits[i].GetComponentInParent<DronePatrol>() ?? hits[i].GetComponent<DronePatrol>();
            if (drone) drone.Reveal();
            var visualCone = hits[i].GetComponentInParent<VisionCone>() ?? hits[i].GetComponent<VisionCone>();
            if (visualCone) visualCone.Reveal();
            var camCone = hits[i].GetComponentInParent<CameraMechanics>() ?? hits[i].GetComponent<CameraMechanics>();
            if (camCone) camCone.Reveal();
            var puzzle = hits[i].GetComponentInParent<PuzzleTile>() ?? hits[i].GetComponent<PuzzleTile>();
            if (puzzle) puzzle.Reveal();
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }
}
