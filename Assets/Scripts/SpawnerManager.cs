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
        GameEventsManager.instance.pickedEvents.OnSelectionDone += NewSpawn;
    }
    void OnDisable()
    {
        GameEventsManager.instance.pickedEvents.OnSelectionDone -= NewSpawn;
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        foreach (var item in spawnPoints)
        {
            Gizmos.DrawSphere(item.transform.position, 0.5f);
        }
    }
}
