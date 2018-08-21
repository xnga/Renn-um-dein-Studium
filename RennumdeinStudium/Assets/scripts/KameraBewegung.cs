using UnityEngine;

//Tutorial: https://www.youtube.com/watch?v=MFQhpwc6cKE

public class KameraBewegung : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 4.0f;
    public Vector3 offset = new Vector3(3.0f, 4.0f, -6.0f);

    void FixedUpdate()
    {
        Vector3 wunschPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, wunschPosition, smoothSpeed);
        transform.position = smoothPosition;

        transform.LookAt(target);
    }


}
