using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePointer : MonoBehaviour
{
    public Transform player;
    public float radius = 1.5f;
    public List<Transform> objectives = new List<Transform>();
    public List<int> index = new List<int>();

    void Update()
    {
        if (index.Count == 0) return;

        Transform target = objectives[index[0]];
        if (!target) return;

        Vector2 dir = (target.position - player.position).normalized;

        transform.position = (Vector2)player.position + dir * radius;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
    public void CompleteObjective(int idx)
    {
        index.Remove(idx);
    }
}
