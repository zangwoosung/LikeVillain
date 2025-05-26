using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.MessageBox;
public class MainUI : MonoBehaviour
{
    [SerializeField] UIDocument myUI;
    
    Button myButton;
    VisualElement root;
    VisualElement clearPage;
    VisualElement gameOverPage;
    Label JumpForce;
    Label Speed;

    Button nextBtn;
    Button quitBtn;

    Button againBtn;
    Button exitBtn;


    private void Start()
    {
        root = myUI.rootVisualElement;
        clearPage = root.Q<VisualElement>("Clear");
        nextBtn = clearPage.Q<Button>("NextBtn");
        quitBtn = clearPage.Q<Button>("QuitBtn");

        nextBtn.clicked += OnMyButtonClick;
        quitBtn.clicked += OnMyButtonClick;

        gameOverPage = root.Q<VisualElement>("GameOver");
        againBtn = gameOverPage.Q<Button>("AgainBtn");
        exitBtn = gameOverPage.Q<Button>("ExitBtn");

        clearPage.style.display = DisplayStyle.None;
        gameOverPage.style.display = DisplayStyle.None;

    }
    void OnEnableTemp()
    {
        // Get the UIDocument component attached to the same GameObject
        // var uiDocument = myUI GetComponent<UIDocument>();

        // Get the root VisualElement
        VisualElement root = myUI.rootVisualElement;

        // Query the Button by name
        myButton = root.Q<Button>("topButton");

        // Register a callback
        if (myButton != null)
        {
            myButton.clicked += OnMyButtonClick;
        }
    }

    private void OnMyButtonClick()
    {
        Debug.Log("Button clicked!");
    }
}