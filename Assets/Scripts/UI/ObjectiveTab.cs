using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTab : MonoBehaviour
{
    public Animator animTab;
    public GameObject objectiveTab;
    public List<GameObject> objectives = new List<GameObject>();
    public ObjectivePointer objectivePointer;
    bool animPlaying = false;

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
        if (!objectiveTab.activeSelf && !animPlaying)
        {
            StartCoroutine(OpenObjective());
        }
        else if (objectiveTab.activeSelf && !animPlaying)
        {
            StartCoroutine(CloseObjective());
        }
    }
    IEnumerator OpenObjective()
    {
        animPlaying = true;
        animTab.Play("ObjectiveOpenn");
        yield return new WaitForSeconds(0.4f);
        objectiveTab.SetActive(true);
        animPlaying = false;
    }
    IEnumerator CloseObjective()
    {
        animPlaying = true;
        objectiveTab.SetActive(false);
        animTab.Play("ObjectiveClose");
        yield return new WaitForSeconds(0.4f);
        animPlaying = false;
    }
}
