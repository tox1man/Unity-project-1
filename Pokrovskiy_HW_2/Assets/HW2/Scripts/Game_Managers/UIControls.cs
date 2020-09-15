using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    private static GameObject _mainMenu;
    private static GameObject _gameOverlayMenu;
    private static GameObject _killCountTextBox;

    private static bool _isMenuOpen = false;
    public static int _killCount = 0;

    private void Awake()
    {
        _mainMenu = GameObject.Find("MainMenuOverlay");
        _mainMenu.SetActive(true);

        _killCountTextBox = GameObject.Find("KillCountText");

        _gameOverlayMenu = GameObject.Find("GameOverlay");
        _gameOverlayMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isMenuOpen == false)
        {
            OpenMenu();
        }
    }

    public static void OpenMenu()
    {
        _mainMenu.SetActive(true);
        _gameOverlayMenu.SetActive(false);

        CameraManager.SetActiveCamera("MenuCamera");
        CameraManager.DeactivateCamera("MainCamera");

        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        HideMenu();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public static void HideMenu()
    {
        _mainMenu.SetActive(false);
        _gameOverlayMenu.SetActive(true);

        CameraManager.SetActiveCamera("MainCamera");
        CameraManager.DeactivateCamera("MenuCamera");

        Time.timeScale = 1;
    }

    public static void UpdateGUIKills()
    {
        Text killCountText = _killCountTextBox.GetComponent<Text>();
        killCountText.text = $"Kills: {_killCount}";
    }
}
