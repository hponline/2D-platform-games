using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;

    public float cameraSpeed;
    public float cameraZ = -10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, cameraZ), cameraSpeed);
    }
}
