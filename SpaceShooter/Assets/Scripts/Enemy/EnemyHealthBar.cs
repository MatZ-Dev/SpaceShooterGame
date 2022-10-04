using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField]
    private Transform bar;

    public float health { get; set; }
    public float maxHealth { get; set; }

    private float healthPercent;

    private void Start()
    {
        health = maxHealth;


    }

    private void Update()
    {
        healthPercent = health / maxHealth;

        bar.localScale = new Vector3(healthPercent, bar.localScale.y);
    }


}
