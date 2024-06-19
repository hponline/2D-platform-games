using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPads : MonoBehaviour
{
    public float bounc = 20.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounc, ForceMode2D.Impulse);
        }
    }
}
