using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public Transform target;

    public float cameraSpeed;
    public float cameraZ = -10;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target  !=null)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, cameraZ), cameraSpeed);
        }       

    }
}
