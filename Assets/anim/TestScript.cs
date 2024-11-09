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
        float speedmult = Random.Range(1, 1.5f);
        Huhrensohn = GetComponent<Animator>();
        Huhrensohn.SetFloat("Offset", offset);
        Huhrensohn.SetFloat("SpeedMult", speedmult);
        GameEventsManager.instance.pickedEvents.OnPicked += CelebratePooper;
        GameEventsManager.instance.cameraEvents.OnFightStart += StartFighting;
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10) > 8)
        {
            SetRandomFloat("AltSadVal");
            SetRandomFloat("HappyAltVal");
        }
    }

    public void SetTrigger(string name)
    {
        Huhrensohn.SetTrigger(name);
    }

    public void SetBool(string name, bool value)
    {
        Huhrensohn.SetBool(name, value);
    }

    public void SetRandomFloat(string name)
    {
        float r = Random.Range(0f, 2f);
        Huhrensohn.SetFloat(name, r);
    }

    void OnEnable()
    {
    }

    private void CelebratePooper(GameObject g)
    {
        if (g == transform.parent.gameObject)
        {
            //            Debug.Log("fucker");
            SetTrigger("Celebrate");
        }
    }

    void OnDisable()
    {
        GameEventsManager.instance.pickedEvents.OnPicked -= CelebratePooper;
        GameEventsManager.instance.cameraEvents.OnFightStart -= StartFighting;
    }

    public void EndCelebrate()
    {
//        Debug.Log("Ending Celebrate");
        GameEventsManager.instance.pickedEvents.SelectionDone(gameObject);
    }

    public void StartFighting()
    {
        SetBool("Fighting", true);
    }
    public void StopFighting(){
        SetBool("Fighting", false);
    }
}
