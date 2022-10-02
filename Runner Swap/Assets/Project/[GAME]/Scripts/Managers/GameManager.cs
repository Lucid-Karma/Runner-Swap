using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool isGameStarted;
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }

    private bool isLevelStarted;
    public bool IsLevelStarted { get { return isLevelStarted; } private set { isLevelStarted = value; } }

    private bool isDead;
    public bool IsDead { get { return (isDead); } set { isDead = value; } }


    public void StartGame()
    {
        if (IsGameStarted || applicationIsQuitting == false)
            return;

        IsGameStarted = true;
        EventManager.OnGameStart.Invoke();
    }

    public void EndGame()
    {
        if (!IsGameStarted || applicationIsQuitting == true)
            return;

        IsGameStarted = false;
        EventManager.OnGameEnd.Invoke();
    }

    void Awake()
    {
        IsGameStarted = true;
        //IsDead = false;
        StartGame();
    }

    void OnEnable()
    {
        //EventManager.OnLevelFail.AddListener(() => IsDead = false);
        EventManager.OnLevelStart.AddListener(() => IsLevelStarted = true);
        EventManager.OnLevelFail.AddListener(() => IsLevelStarted = false);
        EventManager.OnLevelFail.AddListener(() => IsDead = true);
    }
    void OnDisable()
    {
        //EventManager.OnLevelFail.RemoveListener(() => IsDead = false);
        EventManager.OnLevelStart.RemoveListener(() => IsLevelStarted = true);
        EventManager.OnLevelFail.RemoveListener(() => IsLevelStarted = false);
        EventManager.OnLevelFail.RemoveListener(() => IsDead = true);
    }

    /*private void OnEnable()
    {
        EventManager.OnRestart.AddListener(ContinueGame);
        EventManager.OnLevelFail.AddListener(PauseGame);
        EventManager.OnLevelSuccess.AddListener(PauseGame);
        //Timer.OnTimeOut += PauseGame;
    }
    private void OnDisable()
    {
        EventManager.OnRestart.RemoveListener(ContinueGame);
        EventManager.OnLevelFail.RemoveListener(PauseGame);
        EventManager.OnLevelSuccess.RemoveListener(PauseGame);
        //Timer.OnTimeOut -= PauseGame;
    }*/
}
