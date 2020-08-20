using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform[] enemySpawnPoints;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _boss;


    // Start is called before the first frame update
    void Start()
    {
        //спавним мобов
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Transform enemyTransform = e.transform;
            var enemyTemp = Instantiate(_enemy, enemyTransform.position, enemyTransform.rotation, enemyTransform);
            enemyTemp.transform.localScale = enemyTransform.localScale;
        }  
        
        //спавним боссов
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Boss"))
        {
            Transform enemyTransform = e.transform;
            var enemyTemp = Instantiate(_boss, enemyTransform.position, enemyTransform.rotation, enemyTransform);
            enemyTemp.transform.localScale = new Vector3(enemyTransform.localScale.x * 2f, enemyTransform.localScale.y * 2f, enemyTransform.localScale.z * 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
