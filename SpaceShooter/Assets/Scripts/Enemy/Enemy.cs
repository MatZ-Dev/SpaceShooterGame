using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(FlashBehaviour))]
public class Enemy : MonoBehaviour, IDamagable
{
    public event Action<int> EnemyKilled;

    [SerializeField]
    private float health = 3;

    [SerializeField]
    private int pointWorth = 10;

    [SerializeField]
    private EnemyHealthBar enemyHealthBar;

    private FlashBehaviour flashBehaviour;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        flashBehaviour = GetComponent<FlashBehaviour>();
    }

    private void Start()
    {
        enemyHealthBar.maxHealth = health;
    }

    private void Update()
    {
        if (Player.DeathStatic)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        enemyHealthBar.health = health;


        if (health > 0)
        {
            flashBehaviour.Flash();
        }
        else
        {
            Killed();
        }
    }

    private void Killed()
    {
        if (EnemyKilled != null)
        {
            EnemyKilled(pointWorth);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.layer == 8)
        {
            IDamagable damageableObject = c.gameObject.GetComponent<IDamagable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(30);
                Destroy(gameObject);
            }
        }

        
    }
}
