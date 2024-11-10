using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEvent
{
    public event Action<string> OnGameEnd;

    public void GameEnd(string value)
    {
        if (OnGameEnd != null)
        {
            OnGameEnd(value);
        }
    }

    public event Action OnHatsForEveryone;

    public void HatsForEveryone()
    {
        if (OnHatsForEveryone != null)
        {
            OnHatsForEveryone();
        }
    }
}
