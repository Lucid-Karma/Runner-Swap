using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPanels : Panel
{
    public Panel StartGamePanel;
    public Panel CreditsPanel;

    private void Awake() 
    {
        StartGamePanel.ShowPanel();
        CreditsPanel.HidePanel();
    }

    public void InitializeCreditsPanel()
    {
        StartGamePanel.HidePanel();
        CreditsPanel.ShowPanel();
        ShowPanel();
    }

    public void InitializeStartGamePanel()
    {
        StartGamePanel.ShowPanel();
        CreditsPanel.HidePanel();
        ShowPanel();
    }
}
