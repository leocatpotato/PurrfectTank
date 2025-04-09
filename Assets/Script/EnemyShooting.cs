using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    public float fireRate = 3f;
    public AudioClip shootSound;

    private float nextFireTime = 0f;
    private Transform player;
    private AudioSource audioSource;

    private EnemyAI enemyAI;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = gameObject.AddComponent<AudioSource>();
        enemyAI = GetComponent<EnemyAI>();
    }

    void Update()
    {
        if (player == null || enemyAI == null) return;

        if (!enemyAI.IsPlayerDetected()) return;

        Vector3 targetDirection = player.position - transform.position;
        targetDirection.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * 2f);

        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("Did not set Bullet Prefab or Fire Point");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }

        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
