using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LootWeapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D c)
    {
        IWeaponEquip healObject = c.gameObject.GetComponent<IWeaponEquip>();

        if (healObject != null)
        {
            healObject.WeaponEquip();
            Destroy(gameObject);
        }
    }
}

