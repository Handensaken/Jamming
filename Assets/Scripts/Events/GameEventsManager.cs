using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }
    [NonSerialized] public PickedEvent pickedEvents;
    [NonSerialized] public CameraEvents cameraEvents;
    [NonSerialized] public WinEvent winEvents;

    void Awake()
    {
        instance = this;
        pickedEvents = new PickedEvent();
        cameraEvents = new CameraEvents();
        winEvents = new WinEvent();
    }
}
