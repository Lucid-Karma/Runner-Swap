using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartBTN : MonoBehaviour
{
    public void StartLevel()
    {
        EventManager.OnLevelStart.Invoke();
    }

    public void StartRunning()
    {
        EventManager.OnPlayerStartedRunning.Invoke();
    }
}
