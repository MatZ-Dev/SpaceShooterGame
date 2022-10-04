using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGame : MonoBehaviour
{
    private EnemySpawner enemySpawner;

    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();
    }


    void Update()
    {      
        if (!enemySpawner.spawnRunning)
        {
            enemySpawner.StartSpawningEnemies();
        }
    }
}
