using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    [SerializeField] float speed = 1.0f;
    [SerializeField] UI_Inventory uI_Inventory;
    Rigidbody2D rb;
    bool deschis = false;
    public int maxHealth = 100;
    public int Damage = 5;
    int currentHealth;
    private Inventory inventory;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

      inventory = new Inventory();
      uI_Inventory.SetInventory(inventory);

       ItemWorld.SpawnItemWorld(new Vector3(-148, 120,-1), new Item(4,"meat", "c", 0, 0, 12, 0, 20, 0, 0, 1));
       ItemWorld.SpawnItemWorld(new Vector3(-20, 10,-1), new Item(4,"meat", "c", 0, 0, 12, 0, 20, 0, 0, 1));
        ItemWorld.SpawnItemWorld(new Vector3(-100, 10, -1), new Item(4, "wood", "n", 0, 0, 12, 0, 20, 0, 0, 2));

    }

    // Update is called once per frame
    void Update()
    {
        
        float transitionH = Input.GetAxis("Horizontal");
        float transitionV = Input.GetAxis("Vertical");
      
        transitionH *= speed * Time.deltaTime;
        transitionV *= speed * Time.deltaTime;
        rb.velocity = new Vector2(transitionH, transitionV);

        if (transitionV < 0f)
        {
           
            animator.SetBool("FacedBack", false);
            animator.SetBool("FacedLeft", false);
            animator.SetBool("FacedRight", false);
            animator.SetBool("FacedFront", true);
            animator.SetFloat("SpeedV",transitionV);
        }
        if (transitionV > 0f)
        {
            animator.SetBool("FacedFront", false);
            animator.SetBool("FacedLeft", false);
            animator.SetBool("FacedRight", false);
            animator.SetBool("FacedBack", true);
            animator.SetFloat("SpeedV", transitionV);
        }
        if (transitionH < 0f)
        {

            animator.SetBool("FacedBack", false);
            animator.SetBool("FacedRight", false);
            animator.SetBool("FacedFront", false);
            animator.SetBool("FacedLeft", true);
            animator.SetFloat("SpeedH", transitionH);
        }
        if (transitionH > 0f)
        {
            animator.SetBool("FacedFront", false);
            animator.SetBool("FacedLeft", false);
            animator.SetBool("FacedBack", false);
            animator.SetBool("FacedRight", true);
            animator.SetFloat("SpeedH", transitionH);
        }

        transform.Translate(transitionH ,transitionV, 0.0f);
       


    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("TOOK DAMAG");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("YOU DIED");
        Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Chest")
        {
            
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (deschis)
                {
                    FindObjectOfType<Chest>().CloseChest();
                    deschis = false;
                }
                else
                {
                    FindObjectOfType<Chest>().OpenChest();
                    deschis = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        
        if (itemWorld != null)
        {
         
            inventory.AddItem(itemWorld.GetItem());
           
            itemWorld.DestroySelf();

        }
    }


}
