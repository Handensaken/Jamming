using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{   
    private Animator Huhrensohn;
    // Start is called before the first frame update
    void Start()
    {
        float offset = Random.Range(0, 0.9f);
        float speedmult = Random.Range(1,1.5f);
        Huhrensohn = GetComponent<Animator>();
        Huhrensohn.SetFloat("Offset", offset);
        Huhrensohn.SetFloat("SpeedMult", speedmult);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
