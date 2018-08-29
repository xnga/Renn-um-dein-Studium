using UnityEngine;

//Tutorial: https://www.youtube.com/watch?v=MFQhpwc6cKE

public class KameraBewegung : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.1f;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 wunschPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, wunschPosition, smoothSpeed);
        transform.position = smoothPosition;

        transform.LookAt(target);
    }
}
