using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float healt, bulletSpeed;
    
    bool dead = false;

    Transform muzzle;

    public Transform bullet, floatingText, bloodParticle;
    public Slider slider;

    bool mouseIsNotOverUI;

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
        // Bu kod maus UI elementinin üzerinde deðilse true döndürür
        // Bu kod pause menüsünde butonlara basýnca karakterin atýþ yapmasýný engeller
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;
        // Maus Sol týk
        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
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

    public void AmIDead() 
    {
        if (healt <=0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity),3f);
            DataManager.Instance.LoseProcess();
            dead = true;
            Destroy(gameObject);
        }
    }

    // Ateþ etme
    public void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);

        DataManager.Instance.ShotBullet++;
    }

    
}
