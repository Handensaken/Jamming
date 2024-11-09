using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public float time = 4f;
    private float timer;
    private int score;
    public float winScore = 300;
    public Transform winCameraPos;
    public Transform loseCameraPos;
    public List<Transform> CharacterWinPositions;
    public List<Transform> CharacterLosePositions;
    private List<GameObject> yourSquad;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = FindAnyObjectByType<Camera>();
        GameEventsManager.instance.cameraEvents.OnFightStart += InvokeEnding;
    }
    void OnEnable()
    {
    }
    void OnDisable()
    {
        GameEventsManager.instance.cameraEvents.OnFightStart -= InvokeEnding;
    }
    void InvokeEnding()
    {
        Invoke("ChooseEnding", time);
    }
    void ChooseEnding()
    {

        PickManager pickManager = FindAnyObjectByType<PickManager>();
        yourSquad = pickManager.pickedCharacters;
        for (int i = 0; i < pickManager.pickedCharacters.Count; i++)
        {
            score += pickManager.pickedCharacters[i].GetComponent<StrenthOrSomeShit>().strength;
        }
        if (score * 1000 > winScore)
        {
            mainCamera.transform.position = winCameraPos.position;
            for (int i = 0; i < yourSquad.Count; i++)
            {
                //yourSquad[i].transform.position = Vector3.zero;
                yourSquad[i].transform.position = CharacterWinPositions[i].position;
            }
        }
        else
        {
            mainCamera.transform.position = loseCameraPos.position;
            for (int i = 0; i < yourSquad.Count; i++)
            {
                yourSquad[i].transform.position = CharacterWinPositions[i].transform.position;
            }
        }
    }
}
