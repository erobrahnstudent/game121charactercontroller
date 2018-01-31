using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersonmouselook : MonoBehaviour {
    public float minDistance = 4.0f;
    public float maxDistance = 10.0f;
    public float distance = 5.0f;

    public float minPitch = 15.0f;
    public float maxPitch = 80.0f;
    float pitch = 15.0f;

    public float sensitivityX = 10.0f;
    public float sensitivityY = 30.0f;
    public float scrollSensitivity = 5.0f;
    
    float rotationXAxis;
    float rotationYAxis;

    public Transform lookpoint;
    
    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
    }

    void LateUpdate () {
        rotationYAxis += Input.GetAxis("Mouse X") * sensitivityX * distance * 0.02f;
        rotationXAxis -= Input.GetAxis("Mouse Y") * sensitivityY * 0.02f;
        rotationXAxis = ClampAngle(rotationXAxis, minPitch, maxPitch);
        Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                                                   transform.rotation.eulerAngles.y,
                                                   0);
        Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
        Quaternion rotation = toRotation;

        if (Input.GetAxis("Mouse ScrollWheel") > 0 || 
            Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            distance += Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }
        RaycastHit hit;
        if (Physics.Linecast(lookpoint.position, transform.position, out hit))
        {
            distance -= hit.distance;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }
        Vector3 negativeDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negativeDistance + lookpoint.position;
        transform.rotation = rotation;
        transform.position = position;
        // TODO: let player zoom in to a seperate, first person camera view
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}
