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
        health = 5;
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

            EventManager.OnPreLevelFail.Invoke();

            if(health >= 1)
                EventManager.OnPreDieAnimate.Invoke();

            if(health <= 0)
                StartCoroutine(WaitBeforeFail());
        }
    }

    IEnumerator WaitBeforeFail()
    {
        EventManager.OnLevelFail.Invoke();
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
