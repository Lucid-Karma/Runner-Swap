using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunTextBlinker : MonoBehaviour
{
    private Text runText;
    public Text RunText
    {
        get
        {
            if(runText == null)
            runText = GetComponent<Text>();

            return runText;
        }
    }

    public float blinkFadeInTime = 0.3f;
    public float blinkStayTime = 0.4f;
    public float blinkFadeOutTime = 0.5f;
    private float timeChecker = 0;
    private Color color;

    void Start()
    {
        color = RunText.color;
    }

    void Update()
    {
        timeChecker += Time.deltaTime;

        if(timeChecker < blinkFadeInTime)
            RunText.color = new Color(color.r, color.g, color.b, timeChecker / blinkFadeInTime);
        else if(timeChecker < blinkFadeInTime + blinkStayTime)
            RunText.color = new Color(color.r, color.g, color.b, 1);
        else if(timeChecker < blinkFadeInTime + blinkStayTime + blinkFadeOutTime)
            RunText.color = new Color(color.r, color.g, color.b, 1 - (timeChecker - (blinkFadeInTime + blinkStayTime)) / blinkFadeOutTime);
        else
            timeChecker = 0;
    }
}
