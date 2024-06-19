using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeManager : MonoBehaviour
{
    public GameObject sutun;
    
    public float toggleInterval = 2f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToggleObje());
    }

    // Platform gizleme
    IEnumerator ToggleObje()
    {
        while (true)
        {
            if (sutun.activeSelf)
            {
                sutun.SetActive(false);
            }
            else
            {
                sutun.SetActive(true);
            }
            yield return new WaitForSeconds(toggleInterval);
        }
    }
    
}
