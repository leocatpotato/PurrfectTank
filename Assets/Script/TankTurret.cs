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
        Vector3 targetDirection = cameraTransform.forward;
        targetDirection.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        turret.rotation = Quaternion.Slerp(turret.rotation, targetRotation, Time.deltaTime * 5f);
    }

}
