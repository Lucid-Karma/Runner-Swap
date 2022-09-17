using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthTextController : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    public TextMeshProUGUI HealthText
    {
        get
        {
            if(healthText == null)
            healthText = GetComponent<TextMeshProUGUI>();

            return healthText;
        }
    }

    private void OnEnable()
    {
        EventManager.OnPreLevelFail.AddListener(UpdateHealthText);
    }

    private void OnDisable()
    {
        EventManager.OnPreLevelFail.RemoveListener(UpdateHealthText); 
    }

    public int health;
    void Start()
    {
        HealthText.text = "x" + health;
    }

    private void UpdateHealthText()
    {
        health = CharacterTriggerController.health;

        if(health != 0)
            HealthText.text = "x" + health;
        else if(health == 0)
        {
            EventManager.OnLevelFail.Invoke();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
           
    }
}
