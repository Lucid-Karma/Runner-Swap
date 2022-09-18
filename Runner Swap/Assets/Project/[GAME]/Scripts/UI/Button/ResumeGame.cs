using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    public void Resume()
    {
        EventManager.OnLevelResume.Invoke();
        Time.timeScale = 1;
    }
}
