using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public float turnSpeed;
    

    void Update()
    {
        transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime);
    }
}
