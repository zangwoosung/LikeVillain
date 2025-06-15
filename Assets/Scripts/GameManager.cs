using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameOverEvent;
    public static event Action OnStageClearEvent;

    [SerializeField] PlayerData playerData;
    
    void Start()
    {
        playerData.ResetData();

        playerData.OnGameOverEvent += PlayerData_OnGameOverEvent;

        MainUI.OnGameExitEvent += MainUI_OnGameExitEvent; 
        MainUI.OnGameQuitEvent += MainUI_OnGameQuitEvent; 
        MainUI.OnGameAgainEvent += MainUI_OnGameAgainEvent; 
        MainUI.OnGameNextEvent += MainUI_OnGameNextEvent;

        FinishLine.OnStageClearEvent += FinishLine_OnStageClearEvent;

    }
   

    private void FinishLine_OnStageClearEvent()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerData.Life = 0;
        }
    }
    private void PlayerData_OnGameOverEvent()
    {
        Debug.Log("GameManager. Game over");
    }

    private void MainUI_OnGameNextEvent()
    {
        
    }

    private void MainUI_OnGameAgainEvent()
    {
        Debug.Log("again.");
        playerData.ResetData();
    }

    private void MainUI_OnGameQuitEvent()
    {
        Debug.Log("quit");
    }

    private void MainUI_OnGameExitEvent()
    {
        
    }

}
