using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public float time = 4f;
    private float timer;
    private int score;
    void Start()
    {
        GameEventsManager.instance.cameraEvents.OnFightStart += ChooseEnding;
    }
    void OnEnable()
    {
    }
    void OnDisable()
    {
        GameEventsManager.instance.cameraEvents.OnFightStart -= ChooseEnding;
    }

    void Update()
    {

    }
    void InvokeEnding()
    {
        Invoke("ChooseEnding", time);
    }
    void ChooseEnding()
    {
        PickManager pickManager = FindAnyObjectByType<PickManager>();
        for (int i = 0; i < pickManager.pickedCharacters.Count; i++)
        {
            score += pickManager.pickedCharacters[i].GetComponent<StrenthOrSomeShit>().strength;
        }
        Debug.Log(score);
    }
}
