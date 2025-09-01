using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    [System.Serializable]
    public class Entry
    {
        public string title;
        public Sprite image;
        [TextArea] public string description;
    }
    [System.Serializable]
    public class Category
    {
        public string name;
        public Entry[] entries;
    }
    public Category[] categories;

    public Image imageUI;
    public TMP_Text titleUI;
    public TMP_Text descUI;

    int cat = 0;
    int idx = 0;

    void Start()
    {
        Show(cat, idx);
    }
    public void SelectCategory(int categoryIndex)
    {
        cat = Mathf.Clamp(categoryIndex, 0, Mathf.Max(0, categories.Length - 1));
        idx = 0;
        Show(cat, idx);
    }
    public void Next()
    {
        if (categories.Length == 0) return;
        var list = categories[cat].entries;
        if (list == null || list.Length == 0) return;
        idx = (idx + 1) % list.Length;
        Show(cat, idx);
    }

    public void Prev()
    {
        if (categories.Length == 0) return;
        var list = categories[cat].entries;
        if (list == null || list.Length == 0) return;
        idx = (idx - 1 + list.Length) % list.Length;
        Show(cat, idx);
    }

    void Show(int c, int i)
    {
        if (categories == null || categories.Length == 0) return;
        var list = categories[c].entries;
        if (list == null || list.Length == 0)
        {
            imageUI.sprite = null;
            descUI.text = "";
            if (titleUI) titleUI.text = "";
            return;
        }

        var e = list[Mathf.Clamp(i, 0, list.Length - 1)];
        if (imageUI) imageUI.sprite = e.image;
        if (titleUI) titleUI.text = string.IsNullOrEmpty(e.title) ? categories[c].name : e.title;
        if (descUI)  descUI.text  = e.description ?? "";
    }
}
