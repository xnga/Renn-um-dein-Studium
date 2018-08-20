using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosisition : MonoBehaviour {
    public Vector3[] positions; //[] für ein Array für die Position
	// Use this for initialization
	void Start () {
        int randomNumber = Random.Range(0, positions.Length); // minimum,maximum
        transform.position = positions[randomNumber];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
