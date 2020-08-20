using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform[] enemySpawnPoints;
    [SerializeField] private GameObject _enemy;


    // Start is called before the first frame update
    void Start()
    {
        //спавним мобов
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("EnemySpawnPoint"))
        {
            Transform enemyTransform = e.transform;
            var enemyTemp = Instantiate(_enemy, enemyTransform.position, enemyTransform.rotation, enemyTransform);
            enemyTemp.transform.localScale = enemyTransform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
