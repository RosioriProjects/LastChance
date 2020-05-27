using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class BigTree : MonoBehaviour
{

    [SerializeField] GameObject particle;
    [SerializeField] Sprite Hit;
    [SerializeField] Sprite HitBad;

    [SerializeField] public int id_item;
    [SerializeField] public string title;
    [SerializeField] public string equippable_consummable;
    [SerializeField] public int hp_modifier;
    [SerializeField] public int armor_modifier;
    [SerializeField] public int hunger_modifier;
    [SerializeField] public int weather_modifier;
    [SerializeField] public int attack_modifier;
    [SerializeField] public int drop_modifier;
    [SerializeField] public int speed_modifier;

    [SerializeField] public int amount;
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
        ItemWorld.SpawnItemWorld(transform.position, new Item(id_item, title, equippable_consummable, hp_modifier, armor_modifier, hunger_modifier, weather_modifier, attack_modifier, drop_modifier, speed_modifier, amount));
        Destroy(particle);
        Destroy(this.gameObject);
    }
}
