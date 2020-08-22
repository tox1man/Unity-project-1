using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform[] enemySpawnPoints;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _boss;


    void Start()
    {
        //спавним мобов
        foreach (GameObject enemySpawnPoint in GameObject.FindGameObjectsWithTag("EnemySpawnPoint"))
        {
            var enemyTemp = Instantiate(_enemy, enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation, enemySpawnPoint.transform);
            enemyTemp.transform.localScale = enemySpawnPoint.transform.localScale;
        }  
        
        //спавним боссов
        foreach (GameObject bossSpawnPoint in GameObject.FindGameObjectsWithTag("BossSpawnPoint"))
        {
            var bossTemp = Instantiate(_boss, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation, bossSpawnPoint.transform);
            bossTemp.transform.localScale = new Vector3(bossSpawnPoint.transform.localScale.x * 2f, bossSpawnPoint.transform.localScale.y * 2f, bossSpawnPoint.transform.localScale.z * 2f);
        }
    }
}
