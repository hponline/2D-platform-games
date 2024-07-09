using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public Transform bullet, floatingText, bloodParticle;
    public Slider slider;
    public static bool dead = false;
    public float healt, bulletSpeed;

    Transform muzzle;
    bool mouseIsNotOverUI;
          

    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = healt;
        slider.value = healt;

        dead = false;        
    }
     

    void Update()
    {
        // Bu kod maus UI elementinin �zerinde de�ilse true d�nd�r�r
        // Bu kod pause men�s�nde butonlara bas�nca karakterin at�� yapmas�n� engeller
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;
        // Maus Sol t�k
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
        if (healt <=0 && !dead)
        {
            dead = true;
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity),3f);
            // Sahneyi yeniden y�kle
            Invoke("ResetScene", 0.1f);
        }
    }

    // Ate� etme
    public void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);

        //DataManager.Instance.ShotBullet++;
    }

    public void ResetScene()
    {
        StartCoroutine(ResetSceneCoroutine());
    }

    // Death spawn
    public IEnumerator ResetSceneCoroutine()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Sahneyi yeniden y�kle
        SceneManager.LoadScene(currentSceneName);

        // Sahne yeniden y�klendikten sonra biraz bekle
        yield return new WaitForSeconds(0.1f);

        // StartPos pozisyonunu bul
        GameObject spawnPoint = GameObject.Find("StartPos");
        if (spawnPoint != null)
        {            
            // Karakter can� 0 olursa StartPos objesi pozisyonundan yeniden ba�lar    
            transform.position = spawnPoint.transform.position;
            healt += 100;
            slider.value = healt;
            dead = false;
            
        }
        else
        {
            Debug.LogError("Karakter y�kleme hatas�");
        }
    }
}
