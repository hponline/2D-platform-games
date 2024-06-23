using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDiken : MonoBehaviour
{
    public float destroyTime;
    public float dikenDmg;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            other.GetComponent<PlayerManager>().GetDamage(dikenDmg);
        }
    }
}
