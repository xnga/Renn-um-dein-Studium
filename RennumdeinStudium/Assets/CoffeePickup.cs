using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeePickup : MonoBehaviour
{
    //Wie viel Prozent es jeweils hochgeht
    public int healAnzahl = 5;

    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        SpielerScript player = other.GetComponent<SpielerScript>();

        if (player != null)
        {
            player.AlterHealth(healAnzahl);
            gameObject.SetActive(false); // Coffee verschwindet dann
        }
    }

}
