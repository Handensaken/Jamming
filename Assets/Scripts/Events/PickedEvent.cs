using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickedEvent
{
    public event Action<GameObject> OnPicked;
    public void Picked(GameObject character)
    {
        if (OnPicked != null)
        {
            OnPicked(character);
        }
    }
    public event Action<GameObject> OnSelectionDone;
    public void SelectionDone(GameObject character)
    {
        if (OnSelectionDone != null)
        {
            OnSelectionDone(character);
        }
    }
    
}
