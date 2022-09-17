using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterTriggerController : MonoBehaviour
{
    public static int point = 0;
    public static int health = 3;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            point ++;

            EventManager.OnCoinPickUp.Invoke();
            Coin.SharedInstance.DisposeOnTrigger(other);
        }
        else if(other.gameObject.tag == "Obstacle")
        {
            health --;

            if(health != 0)
                EventManager.OnPreLevelFail.Invoke();
            else if(health == 0)
            {
                EventManager.OnLevelFail.Invoke();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
    }
}
