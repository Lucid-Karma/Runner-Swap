using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class PosReferance : MonoBehaviour
{
    public static Vector3 mainPosition;
    public static Vector3 coinPosition;

    void OnEnable()
    {
        EventManager.OnRightMove.AddListener(Pos);
        EventManager.OnLeftMove.AddListener(Pos);
    }
    void OnDisable()
    {
        EventManager.OnRightMove.RemoveListener(Pos);
        EventManager.OnLeftMove.RemoveListener(Pos);
    }

    void Start()
    {
        DOTween.Init();
    }

    public void Pos()
    {
        mainPosition = transform.position;
            if(SwipeController.isItRight)
            {
                mainPosition = Vector3.left * 100;//Vector3.down + Vector3.left * 100; //new Vector3(-100, -1, 0);
                coinPosition = Vector3.left * 3;//Vector3.down + Vector3.left * 3;
            }
            else if(SwipeController.isItLeft)
            {
                mainPosition = Vector3.right * 100;//Vector3.down + Vector3.right * 100; //new Vector3(100, -1, 0);
                coinPosition = Vector3.right * 3;//Vector3.down + Vector3.right * 3;
            }
            else if(SwipeController.isItCenter)
            {
                mainPosition = Vector3.zero;// - Vector3.up;
                coinPosition = Vector3.zero;// - Vector3.up;
            }
        
    }
}
