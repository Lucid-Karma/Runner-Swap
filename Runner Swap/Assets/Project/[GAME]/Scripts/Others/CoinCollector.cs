using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            EventManager.OnCoinPickUp.Invoke();
            Coin.SharedInstance.DisposeOnTrigger(other);
        }
    }
}
