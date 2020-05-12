using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    
    public Inventory()
    {
        itemList = new List<Item>();
        
    }

    public void AddItem(Item item)
    {
        //if (item.IsStackable())
        //{
        //    foreach(Item inventoryItem in itemList)
        //    { bool itemAlreadyInInventory = false;
        //        if(inventoryItem.GetTitle() == item.GetTitle(){
        //            inventoryItem.amount += item.amount;
        //            itemAlreadyInInventory = true;
         //       }

         //   }

       // }
       // else
       // {
            itemList.Add(item);
       // }
       OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    
}
