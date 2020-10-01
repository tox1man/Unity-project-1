using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    private static GameObject _killCountTextBox;
    private static GameObject _mainMenuOverlay;
    private static GameObject _gameOverlay;
    private static GameObject _winOverlay;
    private static GameObject _loseOverlay;

    private static bool _isMenuOpen = false;
    public static int _killCount = 0;

    private void Awake()
    {
        _mainMenuOverlay = GameObject.Find("MainMenuOverlay");
        _gameOverlay = GameObject.Find("GameOverlay");
        _winOverlay = GameObject.Find("WinOverlay");
        _loseOverlay = GameObject.Find("LoseOverlay");
        
        _killCountTextBox = GameObject.Find("KillCountText");
    }

    private void Start() 
    {
        ShowOverlay(_mainMenuOverlay);

        HideOverlay(_winOverlay);
        HideOverlay(_loseOverlay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isMenuOpen == false)
        {
            OpenMainMenu();
        }
    }

    public static void ShowOverlay(GameObject overlayGameObject)
    {
        overlayGameObject.SetActive(true);
    } 

    public static void ShowOverlay(string overlayName)
    {
        GameObject overlay = GameObject.Find("overlayName");
        overlay.SetActive(true);
    } 
    
    public static void HideOverlay(GameObject overlayGameObject)
    {
        overlayGameObject.SetActive(false);
    }

    public static void HideOverlay(string overlayName)
    {
        GameObject overlay = GameObject.Find("overlayName");
        overlay.SetActive(false);
    }

    public static void OpenMainMenu()
    {
        _isMenuOpen = true;

        ShowOverlay(_mainMenuOverlay);
        HideOverlay(_gameOverlay);

        CameraManager.SetActiveCamera("MenuCamera");
        CameraManager.DeactivateCamera("MainCamera");

        Time.timeScale = 0;
    }
    public static void HideMainMenu()
    {
        _isMenuOpen = false;

        ShowOverlay(_gameOverlay);
        HideOverlay(_mainMenuOverlay);

        CameraManager.SetActiveCamera("MainCamera");
        CameraManager.DeactivateCamera("MenuCamera");

        Time.timeScale = 1;
    }

    public void PlayGame()
    {
        HideMainMenu();
    }

    public void RestartGame()
    {
        SceneLoader.ReloadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public static void UpdateGUIKills()
    {
        Text killCountText = _killCountTextBox.GetComponent<Text>();
        killCountText.text = $"Kills: {_killCount}";
    }

    public static void ShowEndGameMenu(bool isGameWon)
    {
        HideOverlay(_gameOverlay);

        if (isGameWon)
        {
            ShowOverlay(_winOverlay);
        }
        else
        {
            ShowOverlay(_loseOverlay);
        }

        CameraManager.SetActiveCamera("MenuCamera");
        CameraManager.DeactivateCamera("MainCamera");

        Time.timeScale = 0;
    }
}
