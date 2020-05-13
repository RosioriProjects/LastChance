using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPointRight;
    public Transform attackPointLeft;
    public Transform attackPointFront;
    public Transform attackPointBack;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timeBtwAttack <= 0)
            {
                Attack();
                timeBtwAttack = startTimeBtwAttack;
            }

        }   
            timeBtwAttack -= Time.deltaTime;
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies=null;
        if (animator.GetBool("FacedRight") == true)
        { hitEnemies = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enemyLayers); }
        if (animator.GetBool("FacedLeft") == true)
        { hitEnemies = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayers); }
        if (animator.GetBool("FacedFront") == true)
        { hitEnemies = Physics2D.OverlapCircleAll(attackPointFront.position, attackRange, enemyLayers); }
        if (animator.GetBool("FacedBack") == true)
        { hitEnemies = Physics2D.OverlapCircleAll(attackPointBack.position, attackRange, enemyLayers); }


        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.tag == "Enemy")
            {
                Debug.Log("We hit " + enemy.name +" for "+ this.GetComponent<Player>().Damage + " damage!");
                enemy.GetComponent<Wolf>().takeDamage(this.GetComponent<Player>().Damage);
                
            }
            
        }
        
    }

     void OnDrawGizmosSelected()
    {
        if (attackPointRight == null) return;
        Gizmos.DrawWireSphere(attackPointRight.position, attackRange);
        if (attackPointLeft == null) return;
        Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
        if (attackPointFront == null) return;
        Gizmos.DrawWireSphere(attackPointFront.position, attackRange);
        if (attackPointBack == null) return;
        Gizmos.DrawWireSphere(attackPointBack.position, attackRange);
    }
}
