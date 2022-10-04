using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    private void OnDestroy()
    {
        if (transform.position.y > -World.instance.boundaries.y)
        {
            GameObject newExplosion = Instantiate(explosionPrefab,transform.position, transform.rotation);
        }
    }
}
