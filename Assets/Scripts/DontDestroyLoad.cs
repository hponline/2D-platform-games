using UnityEngine;

public class DontDestroyLoad : MonoBehaviour
{
    public static DontDestroyLoad Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

