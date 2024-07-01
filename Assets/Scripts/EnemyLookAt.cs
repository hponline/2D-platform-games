using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour
{
    public Transform player;

    public SpriteRenderer spriteRenderer;

    public void LookAtPlayer()
    {
        

        // Oyuncu boss'un saginda ise
        if (transform.position.x > player.position.x)
        {
            
            spriteRenderer.flipX = true;
        }

        else if (transform.position.x < player.position.x)
        {
            
            spriteRenderer.flipX = false;
        }
    }
}
