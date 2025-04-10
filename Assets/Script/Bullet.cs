using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    private bool hasHit = false;
    public GameObject explosionEffect;

    void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return;
        hasHit = true;

        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log("Enemy took " + damage + " damage. Remaining HP: " + enemyHealth.health);
            }
        }

        Destroy(gameObject);
    }
}
