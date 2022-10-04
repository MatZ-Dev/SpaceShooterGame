using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [HideInInspector]
    public bool shoot { private get; set; }

    [SerializeField]
    private Transform[] projectileSpawn;
    [SerializeField]
    private Projectile projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        if (!shoot) return;
        ShootProjectile();
    }

    private void ShootProjectile()
    {
        foreach (Transform projectile in projectileSpawn)
        {
            Projectile newProjectile = Instantiate(projectilePrefab, projectile.position, projectile.rotation) as Projectile;
            newProjectile.spawnLayerMask = gameObject.layer; 
        }
        
    }
}
