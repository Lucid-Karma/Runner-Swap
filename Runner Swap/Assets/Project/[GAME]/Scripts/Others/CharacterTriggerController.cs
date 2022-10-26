using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterTriggerController : MonoBehaviour
{
    public static int point;
    public static int health;

    private float x;
    private float z;
    private float y;

    void Awake()
    {
        point = 0;
        health = 5;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!GameManager.Instance.IsDead)
        {
        if(other.gameObject.CompareTag("coin"))
        {
            point ++;

            EventManager.OnCoinPickUp.Invoke();
            Coin.SharedInstance.DisposeOnTrigger(other);
        }
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            x = other.gameObject.transform.position.x;
            z = other.gameObject.transform.position.z;
            y = other.gameObject.transform.position.y;
            Vector3 Position = new Vector3(x, 1.5f, z);

            //other.gameObject.SetActive(false);
            //GhostManager.Instance.GetGhost(Position);
        
            health --;
            //Debug.Log(health + " " + other.gameObject.name);
            EventManager.OnPreLevelFail.Invoke();

            if(health >= 1)
            {
                EventManager.OnPreDieAnimate.Invoke();

                other.gameObject.SetActive(false);
                GhostManager.Instance.GetGhost(Position);
                StartCoroutine(SetActiveObstacle(other));
            }                

            if(health <= 0)
                StartCoroutine(WaitBeforeFail());
        }
        /*else if(other.gameObject.CompareTag("obsStuff"))
        {
            other.gameObject.SetActive(false);
        }*/
        }
    }

    IEnumerator WaitBeforeFail()
    {
        EventManager.OnLevelFail.Invoke();
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator SetActiveObstacle(Collider obstacle)
    {
        yield return new WaitForSeconds(1.0f);
        obstacle.gameObject.SetActive(true);
    }
}
