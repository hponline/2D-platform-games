using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class BossDeadManager: MonoBehaviour
{
    public float healt;
    public float damage;

    public LayerMask attackMask;
    public float attackRadius;
    
    public int attackDamage = 20;

    
    public Transform attackPoint;

    Animator animator;
    public Slider slider;


    void Start()
    {
        slider.maxValue = healt;
        slider.value = healt;

        
        animator = GetComponent<Animator>();
    }

    



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Collider'e ilk giriþi sayma -- sürekli algýlamamasý için
        if (other.CompareTag("Player"))
        {            
            other.GetComponent<PlayerManager>().GetDamage(damage);
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (other.CompareTag("Bullet"))
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }

    }

  
    // Damage alma
    public void GetDamage(float damage)
    {
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

    // Ölüm kontrol
    public void AmIDead()
    {
        if (healt <= 0)
        {

            animator.SetTrigger("isDead");
            
            Destroy(gameObject,2.5f);
        }        
    }

    

    public void Attack()
    {
        
        Collider2D colInfo = Physics2D.OverlapCircle(attackPoint.position, attackRadius, attackMask);

        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerManager>().GetDamage(attackDamage);
        }
    }

    // boss attack pozisyon/alan gizmosu
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }
    }
}