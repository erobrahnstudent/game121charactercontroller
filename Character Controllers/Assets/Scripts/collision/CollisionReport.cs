using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReport : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        print("Object " + transform.name + " collided with " + collision.gameObject.name);
    }
}
