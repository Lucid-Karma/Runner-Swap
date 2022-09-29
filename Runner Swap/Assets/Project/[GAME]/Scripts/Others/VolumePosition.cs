using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumePosition : MonoBehaviour
{
    void OnEnable()
    {
        //EventManager.OnCenterMove.AddListener(Center);
        EventManager.OnLeftMove.AddListener(Left);
        EventManager.OnRightMove.AddListener(Right);

    }
    void OnDisable()
    {
        //EventManager.OnCenterMove.RemoveListener(Center);
        EventManager.OnLeftMove.RemoveListener(Left);
        EventManager.OnRightMove.RemoveListener(Right);
    }

    private void Center()
    {
        transform.position = Vector3.zero;
        Debug.Log(transform.position.x);
    }
    private void Left()
    {
        if(SwipeController.isItRight)
            {
                transform.position = Vector3.left * 97;
            }
            else if(SwipeController.isItLeft)
            {
                transform.position = Vector3.right * 97;
            }
            else if(SwipeController.isItCenter)
            {
                transform.position = Vector3.zero;
            }
    }
    private void Right()
    {
        if(SwipeController.isItRight)
        {
            transform.position = Vector3.left * 97;
        }
        else if(SwipeController.isItLeft)
        {
            transform.position = Vector3.right * 97;
        }
        else if(SwipeController.isItCenter)
        {
            transform.position = Vector3.zero;
        }
    }
}
