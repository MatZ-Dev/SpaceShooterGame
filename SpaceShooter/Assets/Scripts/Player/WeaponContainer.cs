using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponContainer : MonoBehaviour
{
    public Transform weaponHold;
    public GameObject[] allGuns;
    GameObject equippedGun;


    public void EquipGun(int weaponIndex)
    {
        EquipGun(allGuns[weaponIndex-1]);
    }

    public void EquipGun(GameObject gunToEquip)
    {
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as GameObject;
        equippedGun.transform.parent = weaponHold;
    }


}
