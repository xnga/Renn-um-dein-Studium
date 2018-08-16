using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraBewegung : MonoBehaviour {

    public Transform player;
    private Vector3 distToPlayer;
    public Vector3 distanceToPlayer;
    public float CamStrafeFactor = 1;
    public float CamMoveSmooting = 1;
    public float MouseXValue = 0;

    // Use this for initialization
    void Start()
    {

        if (!player) player = GameObject.Find("Cube").transform;

    }

    // Update is called once per frame
    void Update()
    {

        distToPlayer = player.position + distanceToPlayer;

        MouseXValue += Input.GetAxis("Mouse X") * CamStrafeFactor;
        MouseXValue *= 0.98f;

        distToPlayer += new Vector3(MouseXValue, 0, 0);

        transform.position = Vector3.Lerp(transform.position, distToPlayer, 0.15f * CamMoveSmooting);

    }
}
