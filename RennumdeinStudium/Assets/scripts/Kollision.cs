using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial: https://www.youtube.com/watch?v=QRp4V1JTZnM

public class Kollision : MonoBehaviour
{
    public bool playerDead;

    public GUIStyle HUDStyle; // von pattmann
    public GUIStyle HUDStyle_Dead; // von pattmann
    public int HUDtime = 180; // von pattmann

	void Start()
	{
        playerDead = false;
	}


    void OnGUI() // von pattmann
    {
        GUI.color = Color.white;

        if (HUDtime > 0)
        {
            HUDtime--;
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 100), "ESC to Quit\nR to Restart\nGOOD LUCK ;)", HUDStyle);
        }

        if (playerDead)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 200, 100), " Game Over \n Press R to Restart", HUDStyle_Dead);
        }

    }

    void OnCollisionEnter(Collision colObject)
    {

        if (colObject.gameObject.name == "prefab_tisch(Clone)")
        {
            Destroy(this.gameObject);
            playerDead = true;
        }

        if (colObject.gameObject.name == "prefab_50(Clone)")
        {
            Destroy(this.gameObject);
            playerDead = true;
        }

        if (colObject.gameObject.name == "prefab_baum(Clone)")
        {
            Destroy(this.gameObject);
            playerDead = true;
        }
    }

}