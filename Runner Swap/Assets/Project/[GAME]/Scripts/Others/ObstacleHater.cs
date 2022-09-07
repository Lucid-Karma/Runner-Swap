using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHater : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        /*if(other.gameObject.tag == "coin")
        {
            other.gameObject.SetActive(false);
            Debug.Log("destroyed!");
        }*/
        /*else
        {
            Debug.Log(other.gameObject.tag);
        }*/
        //Debug.Log("wrong!!");
    }
}
