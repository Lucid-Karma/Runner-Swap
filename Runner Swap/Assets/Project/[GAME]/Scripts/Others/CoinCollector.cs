using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            EventManager.OnCoinPickUp.Invoke();
            Coin.SharedInstance.DisposeOnTrigger(other);
            //EventManager.OnPlayerDataUpdated.Invoke();
        }
        else if(other.gameObject.tag == "Obstacle")
        {
            EventManager.OnPreLevelFail.Invoke();
        }
    }
}
