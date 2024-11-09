using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public float maxDistance = 10f;
    public float speed = 5f;
    private bool Hover;
    private Vector3 cameraStartPosition;
    private Vector3 target;

    //Max ooger booger
    private bool _fighting;
    [SerializeField] private Transform _fightingCameraPos;
    void Start()
    {
        //mainCamera = FindAnyObjectByType<Camera>();
        cameraStartPosition = mainCamera.transform.position;
        Debug.Log(cameraStartPosition + " camerpos");
        GameEventsManager.instance.cameraEvents.OnHoverExit += HoverExit;
        GameEventsManager.instance.cameraEvents.OnHoverEnter += HoverEnter;
        GameEventsManager.instance.cameraEvents.OnFightStart += FightStart;
    }
    void OnEnable() { }
    void OnDisable()
    {
        GameEventsManager.instance.cameraEvents.OnHoverEnter -= HoverEnter;
        GameEventsManager.instance.cameraEvents.OnHoverExit -= HoverExit;
        GameEventsManager.instance.cameraEvents.OnFightStart -= FightStart;

    }
    void Update()
    {
        if (Hover)
        {
            mainCamera.transform.position = Vector3.MoveTowards(
                mainCamera.transform.position,
                target,
                speed
            );
        }
        else
        {
            if (!_fighting)
            {
                mainCamera.transform.position = Vector3.MoveTowards(
                    mainCamera.transform.position,
                    cameraStartPosition,
                    speed
                );
            }
        }
    }
    public void HoverEnter(Transform targetTransform)
    {
        Hover = true;
        Vector3 newCameraPos = new Vector3(
            targetTransform.transform.position.x,
            cameraStartPosition.y,
            cameraStartPosition.z
        );
        target = newCameraPos + (targetTransform.position - newCameraPos).normalized * maxDistance;
        //target =cameraStartPosition   + (targetTransform.position - cameraStartPosition).normalized * maxDistance;
    }
    public void HoverExit()
    {
        Hover = false;
        target = mainCamera.transform.position;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(target, 0.5f);
    }
    public void FightStart()
    {
        if (_fightingCameraPos != null)
        {
            Debug.Log("Fight");
            _fighting = true;
            mainCamera.transform.position = _fightingCameraPos.position;
            mainCamera.transform.rotation = _fightingCameraPos.rotation;
        }
    }
}
