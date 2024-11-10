using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public Transform mainCamera;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;
    void Start()
    {
        GameEventsManager.instance.cameraEvents.OnFightStart += InvokeEnding;
    }
    void OnEnable() { }
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
        if (score > winScore)
        {
            mainCamera.transform.position = winCameraPos.position;
            for (int i = 0; i < yourSquad.Count; i++)
            {
                //yourSquad[i].transform.position = Vector3.zero;
                yourSquad[i].transform.position = CharacterWinPositions[i].position;
                yourSquad[i].transform.rotation = CharacterWinPositions[i].rotation;
                if (winText != null)
                {
                    Debug.Log("You did win");
                    if (yourSquad[i].GetComponent<StrenthOrSomeShit>().characterName == "Alive Andy")
                    {
                        Debug.Log("andy??");

                        winText.text = "Somehow Your Team Won with Alive Andy. That Is Impresive";
                    }
                }
                broadcastWinEvent("Win");
            }
        }
        else
        {
            mainCamera.transform.position = loseCameraPos.position;
            for (int i = 0; i < yourSquad.Count; i++)
            {
                yourSquad[i].transform.position = CharacterLosePositions[i].transform.position;
                yourSquad[i].transform.rotation = CharacterLosePositions[i].transform.rotation;
                if (loseText != null)
                {
                    if (yourSquad[i].GetComponent<StrenthOrSomeShit>().name == "Alive Andy")
                    {

                    }
                }
                broadcastWinEvent("Lose");
            }

        }
    }
    private void broadcastWinEvent(string value)
    {
        GameEventsManager.instance.winEvents.GameEnd(value);
    }
}
