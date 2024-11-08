using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints = new Transform[3];
    public List<GameObject> spawnableCharacters = new List<GameObject>();
    private List<GameObject> spawnedCharacters = new List<GameObject>();
    void Start()
    {
        InstantiateCharacters();
    }
    void OnEnable()
    {
        GameEventsManager.instance.pickedEvents.OnPicked += NewSpawn;
    }
    void OnDisable()
    {
        GameEventsManager.instance.pickedEvents.OnPicked -= NewSpawn;
    }
    private void InstantiateCharacters()
    {
        for (int i = 0; i < 3; i++)
        {
            if (spawnableCharacters.Count != 0)
            {
                int tempInt = Random.Range(0, spawnableCharacters.Count);
                spawnedCharacters.Add(Instantiate(spawnableCharacters[tempInt], spawnPoints[i])); 
                spawnableCharacters.RemoveAt(tempInt);
            }
        }
    }
    private void NewSpawn(GameObject gameObject)
    {
        spawnedCharacters.Remove(gameObject);
        foreach (var item in spawnedCharacters)
        {
            Destroy(item);
        }
        InstantiateCharacters();
    }
}
