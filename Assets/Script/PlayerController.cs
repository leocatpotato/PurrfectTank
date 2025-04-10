using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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
        float moveInput = Input.GetAxis("Vertical") * moveSpeed;
        float turnInput = Input.GetAxis("Horizontal") * rotateSpeed * Time.fixedDeltaTime;

        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 moveVelocity = transform.forward * moveInput;
        moveVelocity.y = currentVelocity.y;

        rb.linearVelocity = moveVelocity;

        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, turnInput, 0f));
    }
}
