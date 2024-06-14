using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float healt;
    public float damage;

    bool colliderBusy = false;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = healt;
        slider.value = healt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Collider'e ilk giriþi sayma -- sürekli algýlamamasý için
        if (other.CompareTag("Player") && !colliderBusy)
        {
            colliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if (other.CompareTag("Bullet"))
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {            
            colliderBusy = false;
        }
    }

    // Damage alma
    public void GetDamage(float damage)
    {
        if ((healt - damage) >= 0)
        {
            healt -= damage;
        }
        else
        {
            healt = 0;
        }
        slider.value = healt;
        AmIDead();
    }

    // Ölüm kontrol
    void AmIDead()
    {
        if (healt <= 0)
        {
            DataManager.Instance.EnemyKilled++;
            Destroy(gameObject);
        }
    }
}
