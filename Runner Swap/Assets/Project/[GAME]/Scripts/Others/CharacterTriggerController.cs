using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterTriggerController : MonoBehaviour
{
    public static int point;
    public static int health;

    void Awake()
    {
        point = 0;
        health = 3;
    }

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

            EventManager.OnPreLevelFail.Invoke();

            if(health == 0)
            {
                StartCoroutine(WaitBeforeFail());
                EventManager.OnLevelFail.Invoke();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    IEnumerator WaitBeforeFail()
    {
        //yield return null;
        yield return new WaitForSeconds(2.5f);
        Debug.Log("waited");
        EventManager.OnLevelFail.Invoke();
    }
}
