using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTextController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public TextMeshProUGUI ScoreText
    {
        get
        {
            if(scoreText == null)
            scoreText = GetComponent<TextMeshProUGUI>();

            return scoreText;
        }
    }

    private void OnEnable()
    {
        EventManager.OnCoinPickUp.AddListener(UpdateScoreText);
    }

    private void OnDisable()
    {
        EventManager.OnCoinPickUp.RemoveListener(UpdateScoreText); 
    }

    public int point = 0;
    private void UpdateScoreText()
    {
        point = CharacterTriggerController.point;
        ScoreText.text = "" + point;
    }
}
