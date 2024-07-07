using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float healt, bulletSpeed;
    
    public static bool dead = false;

    Transform muzzle;

    public Transform bullet, floatingText, bloodParticle;
    public Slider slider;

    bool mouseIsNotOverUI;

    
    PlayerController zýplama;

    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = healt;
        slider.value = healt;
        
        DontDestroyOnLoad(gameObject);
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
        if (healt <=0 && !dead)
        {
            dead = true;
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity),3f);
            DataManager.Instance.LoseProcess();
                        
            Invoke("ResetScene", 0.1f);
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

    public void ResetScene()
    {
        StartCoroutine(ResetSceneCoroutine());
    }

    // Death spawn
    private IEnumerator ResetSceneCoroutine()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Sahneyi yeniden yükle
        SceneManager.LoadScene(currentSceneName);

        // Sahne yeniden yüklendikten sonra biraz bekle
        yield return new WaitForSeconds(0.1f);

        // StartPos pozisyonunu bul
        GameObject spawnPoint = GameObject.Find("StartPos");
        if (spawnPoint != null)
        {            
            // Karakter caný 0 olursa StartPos objesi pozisyonundan yeniden baþlar    
            transform.position = spawnPoint.transform.position;
            healt += 100;
            slider.value = healt;
            dead = false;
            zýplama.nextJumpTime = 0;
        }
        else
        {
            Debug.LogError("Karakter yükleme hatasý");
        }
    }
}
