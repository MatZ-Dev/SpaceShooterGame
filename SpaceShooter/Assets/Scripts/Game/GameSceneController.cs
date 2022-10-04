using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent (typeof(RequireComponent))]
public class GameSceneController : MonoBehaviour
{
    public static GameSceneController instance;

    [SerializeField]
    private Player player;

    public bool disableWeaponSpawn { get; private set; }

    private EnemySpawner enemySpawner;

    private WaitForSeconds startCountDownDelay;

    private WaitForSeconds gameOverScreenDelay;

    private int totalPoints;



    private void Awake()
    {
        instance = this;

        enemySpawner = GetComponent<EnemySpawner>();
    }

    private void Start()
    {

        GamePlayUI.instance.healthBar.SetMaxHealth(player.health);

        StartUI.instance.DisableUI();
        GamePlayUI.instance.DisableUI();
        GameOverUI.instance.DisableUI();


        

        player.gameObject.SetActive(false);

        startCountDownDelay = new WaitForSeconds(1);
        gameOverScreenDelay = new WaitForSeconds(1);

        StartCoroutine(GameLoop());
    }


    private void Update()
    {
        disableWeaponSpawn = player.maxWeapon;
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());

        yield return StartCoroutine(RoundPlaying());

        yield return StartCoroutine(GameOver());

    }

    private IEnumerator RoundStarting()
    {
        StartUI.instance.EnableUI();
        GamePlayUI.instance.DisableUI();
        GameOverUI.instance.DisableUI();

        StartUI.instance.CountDownWrite("3");
        yield return startCountDownDelay;

        StartUI.instance.CountDownWrite("2");
        yield return startCountDownDelay;

        StartUI.instance.CountDownWrite("1");
        yield return startCountDownDelay;

        StartUI.instance.CountDownWrite("");

        StartUI.instance.DisableUI();
        GamePlayUI.instance.EnableUI();
        GameOverUI.instance.DisableUI();

        player.gameObject.SetActive(true);

        yield return null;
    }


    private IEnumerator RoundPlaying()
    {
        bool spawnActiveLevel2 = false;
        bool spawnActiveLevel3 = false;

        enemySpawner.StartSpawningEnemies();
        

        while (!Player.DeathStatic)
        {


            if(totalPoints > 100 && !spawnActiveLevel2)
            {
                enemySpawner.StartSpawningEnemiesLvl2();
              
                spawnActiveLevel2 = true;
            }

            if (totalPoints > 1000 && !spawnActiveLevel3)
            {
                enemySpawner.StartSpawningEnemiesLvl3();
                
                spawnActiveLevel3 = true;
            }

            if (totalPoints > 2000)
            {
                enemySpawner.decremtDeleyBasicEnemySpawns = 1f;
            }

            if (totalPoints > 3000)
            {
               enemySpawner.decremtDeleyBasicEnemySpawns = 2f;
            }

            GamePlayUI.instance.healthBar.SetHealth(player.health);
            yield return null;


        }

    }


    private IEnumerator GameOver()
    {
        GameOverUI.instance.score.text = totalPoints.ToString();
        enemySpawner.StopSpawningEnemies();

        player.gameObject.SetActive(false);

        yield return gameOverScreenDelay;

        StartUI.instance.DisableUI();
        GamePlayUI.instance.DisableUI();
        GameOverUI.instance.EnableUI();
    }


    public void EnemyKilled(int pointValue)
    {
        totalPoints += pointValue;
        GamePlayUI.instance.score.text = totalPoints.ToString();
    }
}
