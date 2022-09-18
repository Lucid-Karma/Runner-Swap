using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanels : Panel
{
    public Panel InGameInfoPanel;
    public Panel PauseMenuPanel;
    //public Panel //BlurPanel;

    private void Awake() 
    {
        InGameInfoPanel.HidePanel();
        PauseMenuPanel.HidePanel();
        //BlurPanel.HidePanel();
    }

    private void OnEnable()
    {
        EventManager.OnLevelPause.AddListener(InitializePauseMenuPanel);
        //EventManager.OnLevelSuccess.AddListener(InitializeLevelSuccessPanel);
        EventManager.OnLevelStart.AddListener(InitializeInGameInfoPanel);
        EventManager.OnLevelResume.AddListener(InitializeInGameInfoPanel);
    }

    private void OnDisable()
    {
        EventManager.OnLevelPause.RemoveListener(InitializePauseMenuPanel);
        //EventManager.OnLevelSuccess.RemoveListener(InitializeLevelSuccessPanel);
        EventManager.OnLevelStart.RemoveListener(InitializeInGameInfoPanel);
        EventManager.OnLevelResume.RemoveListener(InitializeInGameInfoPanel);
    }

    private void InitializePauseMenuPanel()
    {
        InGameInfoPanel.HidePanel();
        //BlurPanel.ShowPanel();
        PauseMenuPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeInGameInfoPanel()
    {
        InGameInfoPanel.ShowPanel();
        //BlurPanel.ShowPanel();
        PauseMenuPanel.HidePanel();
        ShowPanel();
    }
}
