using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyBat : MonoBehaviour
{
    public GameObject player;
    
    private Rigidbody2D enemyRb;
    
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        TargetTracking();
    }

    public void TargetTracking()
    {
        // Enemy objemiz takip etmesi için gameObjemizin konumundan
        // kendi konumunu cikarıyor ve surekli olarak bizi takip ediyor.
        Vector3 lookDirection = (player.transform.position - transform.position).normalized * Time.deltaTime;
        enemyRb.AddForce(lookDirection * speed);
        
    }        
}
