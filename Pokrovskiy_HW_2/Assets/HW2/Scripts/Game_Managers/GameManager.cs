using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        GameObject enemy = gameObject.GetComponent<EnemySpawner>()._enemy;
        GameObject boss = gameObject.GetComponent<EnemySpawner>()._boss;

        EnemySpawner.SpawnEnemies(enemy);
        EnemySpawner.SpawnBosses(boss);

        UIControls.OpenMenu();
    }
}
