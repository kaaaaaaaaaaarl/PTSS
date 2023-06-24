using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleTest : MonoBehaviour
{
    ToggleGroup toggleGroupInstance;

    public string SelectedMap;
    public Toggle currentSelection
    {
        get { return toggleGroupInstance.ActiveToggles().FirstOrDefault(); }
    }
    void Start()
    {
        toggleGroupInstance = GetComponent<ToggleGroup>();
        SelectedMap = currentSelection.name;
    }

    public void ToggleChange()
    {
            toggleGroupInstance = GetComponent<ToggleGroup>();
            SelectedMap = currentSelection.name;
    }
}
