using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadsLeft : MonoBehaviour
{
    public float bounc = 50.0f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            rb.AddForce(Vector2.up * bounc, ForceMode2D.Impulse);
        }
        
    }

    

}
