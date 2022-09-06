using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHater : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            Coin.SharedInstance.DisposeOnTrigger(other);
            Debug.Log("destroyed!");
        }
    }
}
