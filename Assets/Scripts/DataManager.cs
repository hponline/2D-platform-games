using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private int shotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;
    public int totalShotBullet;

    EasyFileSave myFile;
    /*
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }

    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "SHOT BULLET : " + shotBullet.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "ENEMY KILLED : " + enemyKilled.ToString();
            WinProcess();
        }
    }

    // Veri kaydetme Baþlangýç iþlemleri
    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }

    // Save Data
    public void SaveData()
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;

        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);

        myFile.Save();
    }

    // Load Data
    public void LoadData()
    {
        if (myFile.Load())
        {
            totalShotBullet += myFile.GetInt("totalShotBullet");
            totalShotBullet += myFile.GetInt("totalEnemyKilled");
        }
        // Her bastýgýmýzda eski verileri üzerine yüklüyor düzeltilecek

    }

    public void WinProcess()
    {
        if (enemyKilled >= 5)
        {
            print("kazandýnýz");
        }
    }

    public void LoseProcess()
    {
        print("Kaybettin");
    }
}
