using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject particle;
    [SerializeField] float moveSpeed;
   // [SerializeField] float moveSpeed = 50f;
    private Player target = null ;
    public bool following;
    Animator animator;
    public int maxHealth=100;
    public int damage = 15;
    int currentHealth;

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
    void Start()
    {
        following = false;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        

    }
    
    // Update is called once per frame
    void Update()
    {
        if (following)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            
            float transitionH = transform.position.x;
            float transitionV = transform.position.y;

            transitionH *= moveSpeed * Time.deltaTime;
            transitionV *= moveSpeed * Time.deltaTime;

            animator.SetFloat("Movement", Mathf.Abs(transitionH) + Mathf.Abs(transitionV));
            if(transitionV <= 0f && transitionH < 0f)
            {
                setAnimator("left");
            }
            else if(transitionV <0f && transitionH >= 0f)
            {
                setAnimator("back");
            }
            else if(transitionV >=0f && transitionH > 0f)
            {
                setAnimator("right");
            }
            else if(transitionV > 0f && transitionH <= 0f)
            {
                setAnimator("front");
            }

        }

       
        
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            
            Die();
        }
    }
     
    void Die()
    {
        Debug.Log("DEAD!");
       
      //  particle.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
        ItemWorld.SpawnItemWorld(transform.position, new Item(id_item, title, equippable_consummable, hp_modifier, armor_modifier, hunger_modifier, weather_modifier, attack_modifier, drop_modifier, speed_modifier, amount));

        Destroy(particle);
        Destroy(this.gameObject);
    }

    private void setAnimator(String directie)
    {
        if (directie == "back")
        {

            animator.SetBool("Back", true);
            animator.SetBool("Front", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }
        else if (directie == "front")
        {
            animator.SetBool("Back", false);
            animator.SetBool("Front", true);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }
        else if (directie == "right")
        {
            animator.SetBool("Back", false);
            animator.SetBool("Front", false);
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else if (directie == "left")
        {
            animator.SetBool("Back", false);
            animator.SetBool("Front", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
        if (collision.gameObject.name == "Player")
        {
          
            following = true;
            target = collision.gameObject.GetComponent<Player>();

           
        }
        
     
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            following = false;
        }
    }






    }
