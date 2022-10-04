using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    [SerializeField]
    private LootHeal lootHealPrefab;
    [SerializeField]
    private LootWeapon lootWeaponPrefab;

  
    private void OnDestroy()
    {

        if ((Mathf.Abs(transform.position.y) <= (World.instance.boundaries.y - 1f)))
        {
            LootSpawn();
        }
    }

    private void LootSpawn()
    {
        int spawnEnable = Random.Range(0, 2);

        if (spawnEnable == 0)
        {
            int randomLoot = Random.Range(0, 4);

            if (randomLoot > 0 || GameSceneController.instance.disableWeaponSpawn)
            {
                SpawnHeal();
            }
            else if(randomLoot == 0)
            {
                SpawnWeapon();
            }

        }
    }

    private void SpawnHeal()
    {
        LootHeal newLootHeal = Instantiate(lootHealPrefab, transform.position, Quaternion.identity) as LootHeal;
    }

    private void SpawnWeapon()
    {
        LootWeapon newLootWeapon = Instantiate(lootWeaponPrefab, transform.position,Quaternion.identity) as LootWeapon;
    }
}
