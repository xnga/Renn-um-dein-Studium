using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWand : MonoBehaviour
{
    public int damagePerBerührung = 5; //Health geht in fünfer Schritten runter
    public float damageAnzahl = 1.0f;

    private List<SpielerScript> playersInWand = new List<SpielerScript>();
    private float damageTickCooldown;

    //Weil wir OnTrigger an haben, wird immer dann, wenn der Player die Wand berührt ontriggerenter aufgerufen
    void OnTriggerEnter(Collider other)
    {
        SpielerScript player = other.GetComponent<SpielerScript>();
        if (player != null)
            playersInWand.Add(player);

        damageTickCooldown = 0.0f;

    }

    //Wenn Player die Wand nicht mehr berührt, dann Wird Ontriggerexit ausgerufe
    void OnTriggerExit(Collider other)
    {

        SpielerScript player = other.GetComponent<SpielerScript>();
        if (player != null)
            playersInWand.Remove(player);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playersInWand.Count > 0)
        {
            if (damageTickCooldown <= 0.0f)
            {
                foreach (SpielerScript player in playersInWand)
                {
                    player.AlterHealth(-1 * damagePerBerührung);
                }
                damageTickCooldown = damageAnzahl;
            }
            else
            {
                damageTickCooldown -= Time.deltaTime;
            }
        }
    }
}

//https://hub.packtpub.com/simple-player-health/