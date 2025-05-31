using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameOverEvent;
    public static event Action OnStageClearEvent;

    
    void Start()
    {
        MainUI.OnGameExitEvent += MainUI_OnGameExitEvent; ;
        MainUI.OnGameQuitEvent += MainUI_OnGameQuitEvent; ;
        MainUI.OnGameAgainEvent += MainUI_OnGameAgainEvent; ;
        MainUI.OnGameNextEvent += MainUI_OnGameNextEvent; ;

    }

    private void MainUI_OnGameNextEvent()
    {
        
    }

    private void MainUI_OnGameAgainEvent()
    {
        
    }

    private void MainUI_OnGameQuitEvent()
    {
        
    }

    private void MainUI_OnGameExitEvent()
    {
        
    }

}
