using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{   
    private Animator Huhrensohn;
    // Start is called before the first frame update
    void Start()
    {
        Huhrensohn = GetComponent<Animator>();
        Huhrensohn.SetFloat("Offset", Random.Range(0, 0.9f));
        Huhrensohn.SetFloat("SpeedMult", Random.Range(1,1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
