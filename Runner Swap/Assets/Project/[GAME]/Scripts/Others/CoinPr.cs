using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPr : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, Time.fixedDeltaTime * 250, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
        }
    }
}
