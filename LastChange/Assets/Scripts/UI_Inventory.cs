using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        this.inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender , System.EventArgs e)
    {
        RefreshInventoryItems();
    }
    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
           if (child == itemSlotTemplate) continue;
           Destroy(child.gameObject);
      }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 58f;

        List<Item> itemList = inventory.GetItemList();
        foreach(Item item in itemList)
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            
            itemSlotRectTransform.anchoredPosition = new Vector2((itemSlotTemplate.position.x) + x * itemSlotCellSize + 3*itemSlotCellSize + itemSlotCellSize/4,(itemSlotTemplate.position.y) - y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            
            x++;
            if (x > 3)
            {
                x = 0;
                y++;
            }
        }
    }
}
