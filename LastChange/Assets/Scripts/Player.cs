using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDatabase {
    public int id_user;
    public string username;
    public string password;
    public string nickname;
    public int hp;
    public int armor;
    public int speed;
    public int attack_value;
    public int hunger;
    public int sickness;
    public int longitude;
    public int latitude;


}


public class Player : MonoBehaviour
{

    public int id_user;
    public string nickname;
    public int sickness;
    public int hunger;
    public int armor;
    Animator animator;
    [SerializeField] GameObject particle;
    [SerializeField] float speed = 1.0f;
    [SerializeField] UI_Inventory uI_Inventory;
    [SerializeField] KeyCode[] toggleInventoryKeys;
    [SerializeField] GameObject inventoryPage;
    Rigidbody2D rb;
    bool deschis = false;
    public int maxHealth = 100;
    public int Damage = 5;
    int currentHealth;
    private Inventory inventory;
    void Start()
    {

        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
        PlayerDatabase loadedPlayer = JsonUtility.FromJson<PlayerDatabase>(json);
        this.gameObject.transform.position =new Vector3 (loadedPlayer.longitude,loadedPlayer.latitude,-2);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;


       inventory = new Inventory();
       uI_Inventory.SetInventory(inventory);

      // ItemWorld.SpawnItemWorld(new Vector3(-148, 120,-1), new Item(4,"meat", "c", 0, 0, 12, 0, 20, 0, 0, 3));
       //ItemWorld.SpawnItemWorld(new Vector3(-20, 10,-1), new Item(4,"meat", "c", 0, 0, 12, 0, 20, 0, 0, 3));
       // ItemWorld.SpawnItemWorld(new Vector3(-100, 10, -1), new Item(4, "wood", "n", 0, 0, 12, 0, 20, 0, 0, 2));


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
       
        for(int i = 0;i < toggleInventoryKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleInventoryKeys[i]))
            {
                inventoryPage.SetActive(!inventoryPage.activeSelf);
                break;
            }
        }

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
        Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(particle);
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOverScene");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Chest")
        {
            Chest chest = FindObjectOfType<Chest>();
            
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (deschis)
                {
                    chest.CloseChest();
                    deschis = false;
                }
                else
                {
                    chest.OpenChest();
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

          //  Touching item
            inventory.AddItem(itemWorld.GetItem());
          
           itemWorld.DestroySelf();
         

        }
    }


}
