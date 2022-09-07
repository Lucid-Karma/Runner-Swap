using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : Singleton<DifficultyManager>
{
    private int currentHealth;
    public int CurrentHelath { get { return currentHealth; } set { currentHealth = value; } } 


    private void OnEnable()
    {
        EventManager.OnCoinPickUp.AddListener(ChangeDifficulty);
    }

    private void OnDisable()
    {
        EventManager.OnCoinPickUp.RemoveListener(ChangeDifficulty);
    }

    private void ChangeDifficulty()
    {
        //TrackManager.Instance.speed ++;
        TrackManager.Instance.speed += 0.125f;
    }
}
