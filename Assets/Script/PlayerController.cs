using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // WASD 控制坦克底盤移動
        float moveInput = Input.GetAxis("Vertical") * moveSpeed;
        float turnInput = Input.GetAxis("Horizontal") * rotateSpeed * Time.fixedDeltaTime;

        rb.linearVelocity = transform.forward * moveInput;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turnInput, 0f));
    }
}
