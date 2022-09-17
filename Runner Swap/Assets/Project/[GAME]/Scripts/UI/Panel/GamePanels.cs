using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanels : Panel
{
    public Panel GameStartPanel;
    public Panel GameEndPanel;
    //public Panel //BlurPanel;

    private void Awake() 
    {
        GameStartPanel.ShowPanel();
        GameEndPanel.HidePanel();
        //BlurPanel.HidePanel();
    }

    private void OnEnable()
    {
        EventManager.OnLevelFail.AddListener(InitializeGameEndPanel);
        //EventManager.OnLevelSuccess.AddListener(InitializeLevelSuccessPanel);
        EventManager.OnGameStart.AddListener(InitializeGameStartPanel);
    }

    private void OnDisable()
    {
        EventManager.OnLevelFail.RemoveListener(InitializeGameEndPanel);
        //EventManager.OnLevelSuccess.RemoveListener(InitializeLevelSuccessPanel);
        EventManager.OnGameStart.RemoveListener(InitializeGameStartPanel);
    }

    private void InitializeGameEndPanel()
    {
        GameStartPanel.HidePanel();
        //BlurPanel.ShowPanel();
        GameEndPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeGameStartPanel()
    {
        GameStartPanel.ShowPanel();
        //BlurPanel.ShowPanel();
        GameEndPanel.HidePanel();
        ShowPanel();
    }
}
