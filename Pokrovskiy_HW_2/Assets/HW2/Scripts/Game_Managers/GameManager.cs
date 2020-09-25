using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region Unity Methods

    private void Start()
    {
        StartGame();
    }

    #endregion

    #region Methods

    private void StartGame()
    {
        GameObject enemy = gameObject.GetComponent<EnemySpawner>()._enemy;
        GameObject boss = gameObject.GetComponent<EnemySpawner>()._boss;

        EnemySpawner.SpawnEnemies(enemy);
        EnemySpawner.SpawnBosses(boss);

        UIControls.OpenMainMenu();
    }

    public static void WinGame()
    {
        UIControls.ShowEndGameMenu(true);
        ResetGameProgress();
    }

    public static void LoseGame()
    {
        UIControls.ShowEndGameMenu(false);
        ResetGameProgress();
    }

    private static void ResetGameProgress()
    {
        UIControls._killCount = 0;
        HitDetector._playerHit = false;
        PlayerWeapon._isReloading = false;
    }

    #endregion
}
