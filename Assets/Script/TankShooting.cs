using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // 砲彈預製體
    public Transform firePoint;      // 砲彈發射位置
    public float bulletSpeed = 15f;  // 砲彈速度

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 按下空白鍵時開火
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("⚠️ bulletPrefab 或 firePoint 未設置！");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed; // 讓砲彈向前飛行
        }
        else
        {
            Debug.LogError("⚠️ bulletPrefab 需要有 Rigidbody！");
        }
    }
}
