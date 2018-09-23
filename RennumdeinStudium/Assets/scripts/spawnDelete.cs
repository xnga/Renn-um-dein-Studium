using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDelete : MonoBehaviour {

    public List<List<GameObject>> spawns;

    public HindernisSpawner allSpawns;

	// Use this for initialization
	void Start () {
        spawns = new List<List<GameObject>>();
	}
	
	// Update is called once per frame
	void Update () {
        spawns.Add(allSpawns.gespawnteHind);
	}
}
