using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject _enemy;
    [SerializeField] public GameObject _boss;
    private Transform[] enemySpawnPoints;

    private static Vector3 _enemySpawnOffset = new Vector3 (0.0f, -0.6f, 0.0f);

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(_enemy);
    }
    public static void SpawnEnemies(GameObject enemyPrefab)
    {
        foreach (GameObject enemySpawnPoint in GameObject.FindGameObjectsWithTag("EnemySpawnPoint"))
        {
            SpawnEnemy(enemySpawnPoint, enemyPrefab);
        }
    }

    public static void SpawnBosses(GameObject bossPrefab)
    {
        foreach (GameObject bossSpawnPoint in GameObject.FindGameObjectsWithTag("BossSpawnPoint"))
        {
            SpawnBoss(bossSpawnPoint, bossPrefab);
        }
    }

    private static void SpawnEnemy(GameObject enemySpawnPoint, GameObject enemyPrefab)
    {
        var enemyTemp = Instantiate(enemyPrefab, enemySpawnPoint.transform.position + _enemySpawnOffset, enemySpawnPoint.transform.rotation, enemySpawnPoint.transform);
        enemyTemp.transform.localScale = enemySpawnPoint.transform.localScale;
    }

    private static void SpawnBoss(GameObject bossSpawnPoint, GameObject bossPrefab)
    {
        var bossTemp = Instantiate(bossPrefab, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation, bossSpawnPoint.transform);
        bossTemp.transform.localScale = bossSpawnPoint.transform.localScale * 2;
        
        //bossTemp.transform.localScale = new Vector3(bossSpawnPoint.transform.localScale.x * 2f, bossSpawnPoint.transform.localScale.y * 2f, bossSpawnPoint.transform.localScale.z * 2f);
    }
}
