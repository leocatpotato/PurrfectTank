using UnityEngine;

public class TankTurret : MonoBehaviour
{
    public Transform turret;
    public Transform cameraTransform;
    void Update()
    {
        RotateTurretToCamera();
    }

    void RotateTurretToCamera()
    {
        Vector3 targetDirection = cameraTransform.forward; // 取得攝影機方向
        targetDirection.y = 0; // 砲塔不抬高，只旋轉水平方向
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        turret.rotation = Quaternion.Slerp(turret.rotation, targetRotation, Time.deltaTime * 5f); // 平滑旋轉
    }

}
