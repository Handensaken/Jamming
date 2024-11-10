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
                    if (yourSquad[i].GetComponent<StrenthOrSomeShit>().characterName == "Victor")
                    {
                        winText.text = "Victor put the V in voluminous, more like the V in Victory";
                    }
                    if (yourSquad[i].GetComponent<StrenthOrSomeShit>().characterName == "Baba Yaga")
                    {
                        winText.text = "Baba Yaga was John Wick in disguise. He was soo cool. All the enemys started running when they saw him";
                    }
                    if (yourSquad[i].GetComponent<StrenthOrSomeShit>().characterName == "Alive Andy")
                    {
                        winText.text = "Somehow your team won with Alive Andy. That is impresive";
                    }
                    if (yourSquad[i].GetComponent<StrenthOrSomeShit>().characterName == "Mr Hat Man")
                    {
                        winText.text = "Damn Mr Hat Man dripped out your whole team. Hats that fancy makes tt hard to lose a battle";
                    }
                    for (int j = 0; j < yourSquad.Count; j++)
                    {
                        if (yourSquad[i].GetComponent<StrenthOrSomeShit>().characterName == "Alive Andy"
                        && yourSquad[j].GetComponent<StrenthOrSomeShit>().characterName == "Slippery Simon")
                        {
                            winText.text = "Alive Andy slid into battle on slippery simon and successfully landed the winning blow";
                        }
                    }
                    for (int j = 0; j < yourSquad.Count; j++)
                    {
                        if (yourSquad[i].GetComponent<StrenthOrSomeShit>().characterName == "Ms Jones"
                        && yourSquad[j].GetComponent<StrenthOrSomeShit>().characterName == "Joe Rogan")
                        {
                            winText.text = "Ms Jones did not have a gun, but luckely Joe Rogan had a spare one. After that victory was a breeze";
                        }
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
                    if (yourSquad[i].GetComponent<StrenthOrSomeShit>().characterName == "Ms Jones")
                    {
                        loseText.text = "You lost hard. You should have brought a gun. Or some better fighters";
                    }
                    if (yourSquad[i].GetComponent<StrenthOrSomeShit>().characterName == "Jen")
                    {
                        loseText.text = "Jen was right, you led the battle and not you lost. Well there is always next time";
                    }
                    if (yourSquad[i].GetComponent<StrenthOrSomeShit>().characterName == "Dominic")
                    {
                        loseText.text = "Dominic found his phone, but... Oh no there is no cell reception. You lost...";
                    }
                    if (yourSquad[i].GetComponent<StrenthOrSomeShit>().characterName == "Alive Andy")
                    {
                        int andyTarget = 0;
                        if (i > 5)
                        {
                            andyTarget = i - 1;
                        }
                        else
                        {
                            andyTarget = i + 1;
                        }
                        loseText.text = "Alive Andy eat " + yourSquad[andyTarget].GetComponent<StrenthOrSomeShit>().characterName
                        + " as a result you lost the battle";
                        Destroy(yourSquad[andyTarget]);
                    }
                    //Baba Yaga
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
