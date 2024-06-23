using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnDiken : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float delayTime = 2.0f;
    public float intervalTime = 2.0f;
    

   

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", delayTime, intervalTime);
        
    }
   
    

    void SpawnObject()
    {   
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        
    }  
}
