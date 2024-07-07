using UnityEngine;

public class PlayerDontDestroyLoad : MonoBehaviour
{
    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private static PlayerDontDestroyLoad instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
    }



}
