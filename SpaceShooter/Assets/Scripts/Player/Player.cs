using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(InputController))]
[RequireComponent (typeof(MovementController))]
[RequireComponent(typeof(WeaponContainer))]
public class Player : MonoBehaviour,IDamagable,IHeal,IWeaponEquip
{
    [SerializeField]
    public float startHealth;

    [SerializeField]
    private GameObject explosionPrefab;

    public static bool DeathStatic;

    private InputController inputController;
    private MovementController movementController;
    private WeaponContainer weaponContainer;

    public float health { get; private set;}
    public bool maxWeapon { get; private set; }

    private int pickedUpWeapon = 1;



    private void Awake()
    {
        inputController = GetComponent<InputController>();
        movementController = GetComponent<MovementController>();
        weaponContainer = GetComponent<WeaponContainer>();
    }

    private void Start()
    {
        movementController.setBoundaries = World.instance.boundaries;
        IntHealth();
        weaponContainer.EquipGun(pickedUpWeapon);
        maxWeapon = false;
    }

    private void FixedUpdate()
    {
        movementController.getDirection = inputController.playerInputDirection;

    }

    private void IntHealth()
    {
        health = startHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DeathStatic = true;
        }
    }

    public void Heal(float heal)
    {
        float healHealth = health + heal;

        if (healHealth >= startHealth)
        {
            healHealth = startHealth;
        }

        health = healHealth;
    }

    private void OnDisable()
    {
        DeathStatic = false;

        GameObject newExplosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
    }

    public void WeaponEquip()
    {
        if(pickedUpWeapon < 3)
        {
            pickedUpWeapon++;

            if (pickedUpWeapon == 2)
            {
                int random = UnityEngine.Random.Range(2, 4);

                weaponContainer.EquipGun(random);
            }

            if (pickedUpWeapon == 3)
            {
                weaponContainer.EquipGun(4);
                maxWeapon = true;
            }
        }
    }

    /*
    public void WeaponReset()
    {
        weaponContainer.EquipGun(1);
    }

    */

}
