using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationPointScript : MonoBehaviour {
    public Transform cameramain;
    public Transform lookpoint;
	void LateUpdate () {
        transform.position = lookpoint.transform.position;
        Quaternion rot = new Quaternion(lookpoint.rotation.x, 
                                        cameramain.rotation.y, 
                                        lookpoint.rotation.z, 
                                        lookpoint.rotation.w);
        transform.rotation = rot;
	}
}
