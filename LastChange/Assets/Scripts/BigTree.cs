using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class BigTree : MonoBehaviour
{

    [SerializeField] GameObject particle;
    [SerializeField] Sprite Hit;
    [SerializeField] Sprite HitBad;
    public int maxHealth;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;    
    }


    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 2 * maxHealth / 3 && currentHealth>maxHealth/3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Hit;
        }
        if(currentHealth<maxHealth/3 && currentHealth > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = HitBad;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(particle);
        Destroy(this.gameObject);
    }
}
