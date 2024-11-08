using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickManager : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [NonSerialized] public List<GameObject> pickedCharacters = new List<GameObject>();
    void Start()
    {
        MainCamera = FindAnyObjectByType<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPick();
        }
    }
    public void AddCharacters(GameObject character)
    {
        pickedCharacters.Add(character);
    }
    private void TryPick()
    {
        Debug.Log("idk");
        RaycastHit hit;
        if (Physics.Raycast(MainCamera.ScreenToWorldPoint(Input.mousePosition), MainCamera.transform.forward, out hit, 1000f))
        {
            Debug.Log("pppp");
            Debug.Log(hit);
            GameObject pickedObject = hit.collider.gameObject;
            if (pickedObject.tag == "Pickable")
            {
                pickedCharacters.Add(pickedObject);
                Destroy(pickedObject);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (MainCamera != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(MainCamera.ScreenToWorldPoint(Input.mousePosition), MainCamera.transform.forward);
            }
        
    }
}
