using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnDiken : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float delayTime = 2.0f;
    public float intervalTime = 2.0f;
    public float dikenDmg;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", delayTime, intervalTime);
        
    }
   
    

    void SpawnObject()
    {   
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //EnemyManager playerManager = collision.gameObject.GetComponent<EnemyManager>();
            //playerManager.GetDamage(dikenDmg);
            other.GetComponent<EnemyManager>().GetDamage(dikenDmg);
        }
    }
    // yukarýdan düþen dikenlerden dmg alma sistemi düzeltilecek

}
