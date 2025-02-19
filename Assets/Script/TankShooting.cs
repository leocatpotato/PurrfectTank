using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    public float fireRate = 3f;
    public AudioClip shootSound;

    private float nextFireTime = 0f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("Did not setting bulletPrefab or firePoint");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
        else
        {
            Debug.LogError("Did not setting shootSound");
        }

        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
        else
        {
            Debug.LogError("bulletPrefab need Rigidbody！");
        }
    }
}
