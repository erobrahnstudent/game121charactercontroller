using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersonmovement : MonoBehaviour {
    public float speed = 10.0f;
    public GameObject player;
    bool moving;
    void Update()
    {
        moving = false;
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
            moving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -transform.forward;
            moving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -transform.right;
            moving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
            moving = true;
        }
        moveDirection.y = 0.0f;
        player.transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);
        if (moving) player.transform.rotation = Quaternion.LookRotation(moveDirection);
    }
}
