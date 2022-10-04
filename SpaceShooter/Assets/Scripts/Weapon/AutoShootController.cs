using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShootController : MonoBehaviour
{

    public Vector3 ShootObjectVelocity { private get;  set; }

    [SerializeField]
    private float msBetweenShots = 20f;
    [SerializeField]
    private float projectileSpeed = 10f;

    [SerializeField]
    private Transform[] projectileSpawn;
    [SerializeField]
    private Projectile projectilePrefab;


    private float nextShotTime;


    private void Update()
    {
        ShootProjectile();
    }

    private void ShootProjectile()
    {
        if (Time.time <= nextShotTime) return;

        nextShotTime = Time.time + msBetweenShots / 1000;

        foreach (Transform projectile in projectileSpawn)
        {
            Projectile newProjectile = Instantiate(projectilePrefab, projectile.position, projectile.rotation) as Projectile;
            newProjectile.speed = projectileSpeed;
            newProjectile.spawnLayerMask = gameObject.layer;
        }
    }
}
