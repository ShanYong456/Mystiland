using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Transform itemSlotBackground;
    private Transform cancel_button;

    private void Awake(){
        itemSlotContainer = transform.Find("inventory");
        cancel_button = transform.Find("close_button");
        itemSlotTemplate = itemSlotContainer.Find("inventory_slot_1");
        itemSlotBackground = transform.Find("inventory_background");
        Close_inventory();
        
    }

    public void SetInventory(Inventory inventory){
        this.inventory = inventory;
    
        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems(){
        foreach (Transform child in itemSlotContainer){
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 20f;
        int slots = 20;
        int num_items_in_inventory = inventory.GetItemList().Count;
        if (num_items_in_inventory >= 1){
            foreach (Items item in inventory.GetItemList()){
                if (slots > 0){
                    
                    RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                    itemSlotRectTransform.gameObject.SetActive(true);
                    itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                    Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
                    image.sprite = item.GetSprite();

                    TextMeshProUGUI uiText = itemSlotRectTransform.Find("amount_text").GetComponent<TextMeshProUGUI>();
                    if (item.amount > 1){
                        uiText.SetText(item.amount.ToString());
                    }else{
                        uiText.SetText("");
                    }
                    
                    slots--;
                    x++;
                    if (x > 3){
                        x = 0;
                        y--;
                    }
                }
            
            }
            
        }
        if (slots > 0){
            int empty_slots = slots;
            for (int i=0; i<empty_slots; i++){
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
                image.sprite = null;
                image.color = Color.grey;
                TextMeshProUGUI uiText = itemSlotRectTransform.Find("amount_text").GetComponent<TextMeshProUGUI>();
                x++;
                if (x > 3){
                    x = 0;
                    y--;
                }
            }
        }
        
    }
    
    public void Close_inventory(){
        itemSlotContainer.gameObject.SetActive(false);
        itemSlotTemplate.gameObject.SetActive(false);
        itemSlotBackground.gameObject.SetActive(false);
        cancel_button.gameObject.SetActive(false);
    }

    public void Open_inventory(){
        itemSlotContainer.gameObject.SetActive(true);
        itemSlotTemplate.gameObject.SetActive(true);
        itemSlotBackground.gameObject.SetActive(true);
        cancel_button.gameObject.SetActive(true);
    }


}
