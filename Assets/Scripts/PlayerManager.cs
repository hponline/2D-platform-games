using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float healt, bulletSpeed;
    
    bool dead = false;

    Transform muzzle;

    public Transform bullet, floatingText;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = healt;
        slider.value = healt;
    }

    // Update is called once per frame
    void Update()
    {
        // Maus Sol týk
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }

    }

    // Damage alma
    public void GetDamage(float damage)
    {
        // Floating Text
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
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

    void AmIDead() 
    {
        if (healt <=0)
        {
            dead = true;
        }
    }

    // Ateþ etme
    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
    }
}
