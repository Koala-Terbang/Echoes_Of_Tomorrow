using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    HashSet<string> keys = new HashSet<string>();

    public void Add(string id)
    {
        if (!string.IsNullOrEmpty(id))
            keys.Add(id);
    }
    public bool Has(string id)
    {
        return keys.Contains(id);
    }    
    public bool Use(string id)
    {
        if (!keys.Contains(id))
            return false;
        keys.Remove(id);
        return true;
    }
}
