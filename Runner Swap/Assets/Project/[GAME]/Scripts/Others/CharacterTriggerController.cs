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
        if(other.gameObject.CompareTag("coin"))
        {
            point ++;

            EventManager.OnCoinPickUp.Invoke();
            Coin.SharedInstance.DisposeOnTrigger(other);
        }
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            health --;

            //if(health > 0)
                EventManager.OnPreLevelFail.Invoke();

            if(health <= 0)
            {
                StartCoroutine(WaitBeforeFail());
            }
        }
    }

    IEnumerator WaitBeforeFail()
    {
        Debug.Log("wait");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("waited");
        EventManager.OnLevelFail.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
