using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    public bool IsHidden { get; private set; }

    public void SetHidden(bool value)
    {
        IsHidden = value;
    }
}
