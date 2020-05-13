using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator animator;
    [SerializeField] UI_Inventory uI_Inventory;
    [SerializeField] GameObject inventoryPage;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        
        animator = GetComponent<Animator>();
        uI_Inventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenChest()
    {
        inventoryPage.SetActive(!inventoryPage.activeSelf);
        animator.SetBool("Open", true);
        

    }
    public void CloseChest()
    {
        animator.SetBool("Open", false);
        inventoryPage.SetActive(!inventoryPage.activeSelf);

    }
}
