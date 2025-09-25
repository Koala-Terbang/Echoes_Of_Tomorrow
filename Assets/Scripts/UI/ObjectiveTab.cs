using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTab : MonoBehaviour
{
    public GameObject tabPanel;
    public List<GameObject> objectives = new List<GameObject>();
    public ObjectivePointer objectivePointer;

    void Start()
    {
        tabPanel.SetActive(false);
    }
    void Update()
    {
        foreach (GameObject obj in objectives)
        {
            obj.SetActive(false);
        }

        if (objectivePointer.index.Count > 0 && objectivePointer.index[0] < objectives.Count)
        {
            objectives[objectivePointer.index[0]].SetActive(true);
        }
    }
    public void ToggleObjective()
    {
        bool isActive = tabPanel.activeSelf;
        tabPanel.SetActive(!isActive);
    }
}
