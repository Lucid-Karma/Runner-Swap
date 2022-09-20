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
        EventManager.OnPlayerStartedRunning.Invoke();
        EventManager.OnLevelStart.Invoke();
    }
}
