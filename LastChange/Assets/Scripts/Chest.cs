using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator animator;
    [SerializeField] UI_Inventory uI_Inventory;
    [SerializeField] GameObject inventoryPage;
    [SerializeField] UI_Inventory playerInv;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        
        animator = GetComponent<Animator>();
        uI_Inventory.SetInventory(inventory);
    }

    public Inventory GetInventory()
    {
        return this.inventory;
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

    public void Transfer()
    {
       // Debug.Log(inventory.GetItemList());
        uI_Inventory.transfer(playerInv);
        
    }
}
