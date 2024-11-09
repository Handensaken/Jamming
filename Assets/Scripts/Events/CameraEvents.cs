using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CameraEvents
{
    public event Action<Transform> OnHoverEnter;
    public void HoverEnter(Transform character)
    {
        if (OnHoverEnter != null)
        {
            OnHoverEnter(character);
        }
    }
    public event Action OnHoverExit;
    public void HoverExit()
    {
        if (OnHoverExit != null)
        {
            OnHoverExit();
        }
    }
}
