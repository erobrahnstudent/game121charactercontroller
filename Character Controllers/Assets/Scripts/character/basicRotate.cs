using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicRotate : MonoBehaviour {
    public float rotationSpeed = 16.0f; // Degrees per second

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
