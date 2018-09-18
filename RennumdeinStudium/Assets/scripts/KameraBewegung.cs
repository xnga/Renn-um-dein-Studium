using UnityEngine;

//Tutorial: https://www.youtube.com/watch?v=MFQhpwc6cKE

public class KameraBewegung : MonoBehaviour {

    public Transform PlayerTransform;

    private Vector3 CameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = false;

    public bool RotateAroundPlayer = true;

    public float RotationSpeed = 0.5f;

    void Start()
    {
        CameraOffset = transform.position - PlayerTransform.position; 
    }

    // LateUpdater nach Updates aufgerufen
    void LateUpdate()
    {
        if (RotateAroundPlayer) {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            CameraOffset = camTurnAngle * CameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + CameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotateAroundPlayer ) {
            transform.LookAt(PlayerTransform);
        }
    }



}
