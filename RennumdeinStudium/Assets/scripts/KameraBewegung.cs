using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tutorial: https://www.youtube.com/watch?v=hRRqxrWQJQg

public class KameraBewegung : MonoBehaviour
{

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    private void LateUpdate()
    {
        Neuladen();
    }

    public void Neuladen()
    {

        // Position bestimmen
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = player.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = player.position + offsetPosition;
        }

        // Rotation bestimmen
        if (lookAt)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.rotation = player.rotation;
        }
    }
}