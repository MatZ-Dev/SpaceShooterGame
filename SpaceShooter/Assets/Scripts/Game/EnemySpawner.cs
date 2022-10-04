using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float startDeleyBetweenBasicEnemySpawns = 3f;

    public float decremtDeleyBasicEnemySpawns { get; set;}

    [SerializeField]
    private float deleyBetweenShootEnemySpawns = 15f;

    [SerializeField]
    private float deleyBetweenHoverEnemySpawns = 20f;

    [SerializeField]
    private Enemy[] basicEnemyPrefab;
    [SerializeField]
    private Enemy shootEnemyPrefab;
    [SerializeField]
    private Enemy hoverEnemyPrefab;

    public bool spawnRunning { get; private set; }

    private WaitForSeconds waitBasicWave;
    private WaitForSeconds waitShootWave;
    private WaitForSeconds waitHoverWave;

    private void Start()
    {
        waitShootWave = new WaitForSeconds(deleyBetweenShootEnemySpawns);
        waitHoverWave = new WaitForSeconds(deleyBetweenHoverEnemySpawns);
    }

    public void StartSpawningEnemies()
    {
        StartCoroutine("CO_SpawnEnemies");
        //StartCoroutine("CO_SpawnHoverEnemies");
    }

    public void StopSpawningEnemies()
    {
        StopCoroutine("CO_SpawnEnemies");
        StopCoroutine("CO_SpawnShootEnemies");
        StopCoroutine("CO_SpawnHoverEnemies");
    }

    private IEnumerator CO_SpawnEnemies()
    {
        spawnRunning = true;
        float deleyBetweenBasicEnemySpawns = startDeleyBetweenBasicEnemySpawns;

        while (true)
        {
            SpawnRowOfBasicEnemies();

            if (deleyBetweenBasicEnemySpawns > 1f)
            {
                deleyBetweenBasicEnemySpawns = startDeleyBetweenBasicEnemySpawns - decremtDeleyBasicEnemySpawns;
            }

            yield return new WaitForSeconds(deleyBetweenBasicEnemySpawns); ;
        }
        spawnRunning = false;
    }


    public void StartSpawningEnemiesLvl2()
    {
        StartCoroutine("CO_SpawnShootEnemies");
    }

    private IEnumerator CO_SpawnShootEnemies()
    {
        while (true)
        {
            ShootEnemySpawn();
            yield return waitShootWave;
        }
    }

    public void StartSpawningEnemiesLvl3()
    {
        StartCoroutine("CO_SpawnHoverEnemies");
    }

    private IEnumerator CO_SpawnHoverEnemies()
    {
        while (true)
        {
            
            HoverEnemySpawn();
            yield return waitHoverWave;
        }
    }

    private static Vector2 GetRandomSpawnPosition()
    {
        float horizontalPosition = UnityEngine.Random.Range(-World.instance.boundaries.x + .9f, World.instance.boundaries.x - .9f);
        Vector2 spawnPosition = new Vector2(horizontalPosition, World.instance.boundaries.y);
        return spawnPosition;
    }

    private void SpawnRowOfBasicEnemies()
    {
        for (int i = 0; i < 6; i++)
        {

            int randomEnemy = UnityEngine.Random.Range(0, basicEnemyPrefab.Length);
            int randomEnableSpawn = UnityEngine.Random.Range(0, 2);

            if (randomEnableSpawn == 1)
            {
                Enemy enemy = Instantiate(basicEnemyPrefab[randomEnemy],transform.position, transform.rotation) as Enemy;
                enemy.EnemyKilled += GameSceneController.instance.EnemyKilled;
                float position = (-World.instance.boundaries.x + .9f) + i;
                enemy.transform.position = new Vector2(position, World.instance.boundaries.y);
            }
        }
    }


    private void HoverEnemySpawn()
    {
        Enemy enemy = Instantiate(hoverEnemyPrefab) as Enemy;

        float position = UnityEngine.Random.Range(-1f, 2f);

        enemy.transform.position = new Vector2(position, World.instance.boundaries.y);

        enemy.EnemyKilled += GameSceneController.instance.EnemyKilled;


    }

    private void ShootEnemySpawn()
    {
        Enemy enemy = Instantiate(shootEnemyPrefab) as Enemy;
        enemy.transform.position = GetRandomSpawnPosition();

        enemy.EnemyKilled += GameSceneController.instance.EnemyKilled;
    }


}
