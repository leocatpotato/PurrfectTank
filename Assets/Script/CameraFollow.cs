using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 玩家坦克
    public Vector3 offset = new Vector3(0, 5, -8); // 預設攝影機位置
    public float sensitivity = 2f; // 滑鼠靈敏度
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 鎖定滑鼠在畫面中間
    }

    void Update()
    {
        // 滑鼠左右旋轉視角
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -30f, 60f); // 限制上下旋轉範圍

        // 設定攝影機的旋轉
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
        transform.position = target.position + rotation * offset;
        transform.LookAt(target.position);
    }
}
