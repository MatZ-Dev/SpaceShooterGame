using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public float speed { private get; set; }

    [SerializeField]
    private float lifetime = 3f;

    public LayerMask spawnLayerMask { get; set; }

    private void Start() => Destroy(gameObject, lifetime);



    private void FixedUpdate() => transform.localPosition += transform.up * speed * Time.fixedDeltaTime;


    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == spawnLayerMask) return;

        IDamagable damageableObject = c.gameObject.GetComponent<IDamagable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
