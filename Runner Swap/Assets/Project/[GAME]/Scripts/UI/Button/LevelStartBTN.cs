using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStartBTN : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //EventManager.OnLevelStart.Invoke();
    }

    public void StartRunning()
    {
        EventManager.OnLevelStart.Invoke();
        EventManager.OnPlayerStartedRunning.Invoke();
        gameObject.SetActive(false);
    }
}
