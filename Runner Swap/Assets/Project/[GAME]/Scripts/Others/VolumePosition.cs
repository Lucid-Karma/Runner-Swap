using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumePosition : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnCenterMove.AddListener(Center);
        EventManager.OnLeftMove.AddListener(Left);
        EventManager.OnRightMove.AddListener(Right);

    }
    void OnDisable()
    {
        EventManager.OnCenterMove.RemoveListener(Center);
        EventManager.OnLeftMove.RemoveListener(Left);
        EventManager.OnRightMove.RemoveListener(Right);
    }

    private void Center()
    {
        transform.position = Vector3.zero;
    }
    private void Left()
    {
        transform.position = new Vector3(97, 0, 0);
    }
    private void Right()
    {
        transform.position = new Vector3(-97, 0, 0);
    }
}
