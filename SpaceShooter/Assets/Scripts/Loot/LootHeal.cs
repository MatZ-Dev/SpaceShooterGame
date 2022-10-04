using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class LootHeal : MonoBehaviour
{
    [SerializeField]
    private float healthRestore = 10f;

    private void OnTriggerEnter2D(Collider2D c)
    {
        IHeal healObject = c.gameObject.GetComponent<IHeal>();

        if (healObject != null)
        {
            healObject.Heal(healthRestore);
            Destroy(gameObject);
        }
    }
}
