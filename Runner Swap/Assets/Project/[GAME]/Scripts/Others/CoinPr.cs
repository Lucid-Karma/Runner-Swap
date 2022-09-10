using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class CoinPr : MonoBehaviour
{
    void Start()
    {
        //DOTween.Init();
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, Time.fixedDeltaTime * 250, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            //Debug.Log("destroyed!");
        }
    }
}
