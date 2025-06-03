using System;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;
public class MainUI : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    public static event Action OnGameExitEvent;
    public static event Action OnGameQuitEvent;
    public static event Action OnGameAgainEvent;
    public static event Action OnGameNextEvent;

    [SerializeField] UIDocument myUI;
       
    VisualElement root;
    VisualElement mainPage;
    VisualElement clearPage;
    VisualElement gameOverPage;
    

    Button nextBtn;
    Button quitBtn;

    Button againBtn;
    Button exitBtn;

    private void Awake()
    {
        root = myUI.rootVisualElement;

        mainPage = root.Q<VisualElement>("Main");
        clearPage = root.Q<VisualElement>("Clear");
        nextBtn = clearPage.Q<Button>("NextBtn");
        exitBtn = clearPage.Q<Button>("ExitBtn");      

        gameOverPage = root.Q<VisualElement>("GameOver");
        againBtn = gameOverPage.Q<Button>("AgainBtn");
        quitBtn = gameOverPage.Q<Button>("QuitBtn");       

        clearPage.visible = false;
        gameOverPage.visible = false;
        mainPage.visible = true;

        playerData.OnGameOverEvent += GameManager_OnGameOverEvent;
    }

   

    private void Start()
    {
        GameManager.OnGameOverEvent += GameManager_OnGameOverEvent;
        GameManager.OnStageClearEvent += GameManager_OnStageClearEvent;

        nextBtn.clicked += OnNextButtonClick;
        exitBtn.clicked += OnExitButtonClick;

        againBtn.clicked += OnAgainButtonClick;
        quitBtn.clicked += OnQuitButtonClick;

    }

    private void OnExitButtonClick()
    {
        OnGameExitEvent?.Invoke();
    }

    private void OnNextButtonClick()
    {        
        OnGameNextEvent?.Invoke();
    }

    private void OnQuitButtonClick()
    {
        OnGameExitEvent?.Invoke();
    }

    private void OnAgainButtonClick()
    {
        clearPage.visible = false;
        gameOverPage.visible = false;
        OnGameAgainEvent?.Invoke();
    }   

    private void GameManager_OnStageClearEvent()
    {
        clearPage.visible = true;
    }

    private void GameManager_OnGameOverEvent()
    {
        gameOverPage.visible = true;
    }

    
}