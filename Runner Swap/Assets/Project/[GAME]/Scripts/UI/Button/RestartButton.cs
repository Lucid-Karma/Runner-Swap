using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex - 1 );
        EventManager.OnRestart.Invoke();
    }
}
