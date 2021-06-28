using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quick_access_slots : MonoBehaviour
{
    private quick_access quick_access;
    private Transform quick_access_container;
    private Transform quick_access_access_slot;
    private Transform access_inventory_container;
    private Transform access_inventory;
    private bool inventory_slot_exist = false;
    
     private void Awake(){
        quick_access_container = transform.Find("quick_access_slots");
        quick_access_access_slot = quick_access_container.Find("quick_access_slot_1");
        access_inventory_container = transform.Find("access_inventory");
        access_inventory = access_inventory_container.Find("inventory_slot");
        
        
    }

     public void SetQuickAccess(quick_access quick_access){
        this.quick_access = quick_access;
    
        quick_access.OnQuickAccessListChanged += quick_access_OnQuickAccessListChanged;

        RefreshQuickAccessItems();
        
    }

    private void quick_access_OnQuickAccessListChanged(object sender, System.EventArgs e){
        RefreshQuickAccessItems();
    }


    private void RefreshQuickAccessItems(){
        foreach (Transform child in quick_access_container){
            if (inventory_slot_exist == false){
             add_inventory_slot();
             inventory_slot_exist = true;
            }
            if (child == quick_access_access_slot) continue;
            Destroy(child.gameObject);
        }
       
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 20f;
        int slots = 7;
        int num_items_in_quick_access = quick_access.GetQuickAccessList().Count;
        if (num_items_in_quick_access >= 1){
            foreach (Items item in quick_access.GetQuickAccessList()){
                if (slots > 0){
                    
                    RectTransform itemSlotRectTransform = Instantiate(quick_access_access_slot, quick_access_container).GetComponent<RectTransform>();
                    itemSlotRectTransform.gameObject.SetActive(true);
                    itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                    Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
                    image.sprite = item.GetSprite();
                    TextMeshProUGUI slot_num = itemSlotRectTransform.Find("Text").GetComponent<TextMeshProUGUI>();
                    slot_num.SetText((x+1).ToString());
                    TextMeshProUGUI uiText = itemSlotRectTransform.Find("amount_text").GetComponent<TextMeshProUGUI>();
                    if (item.amount > 1){
                        uiText.SetText(item.amount.ToString());
                    }else{
                        uiText.SetText("");
                    }
                    
                    slots--;
                    x++;
                    
                }
            
            }
            /*if (inventory_slot_exist == false){
                RectTransform InventoryRectTransform = Instantiate(access_inventory, quick_access_container).GetComponent<RectTransform>();
                InventoryRectTransform.gameObject.SetActive(true);
                InventoryRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                inventory_slot_exist = true;
            }*/
           
            
        }
        if (slots > 0){
            int empty_slots = slots;
            for (int i=0; i<empty_slots; i++){
                RectTransform itemSlotRectTransform = Instantiate(quick_access_access_slot, quick_access_container).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
                image.sprite = null;
                image.color = Color.grey;
                TextMeshProUGUI slot_num = itemSlotRectTransform.Find("Text").GetComponent<TextMeshProUGUI>();
                slot_num.SetText((x+1).ToString());
                TextMeshProUGUI uiText = itemSlotRectTransform.Find("amount_text").GetComponent<TextMeshProUGUI>();
                uiText.SetText("");
                x++;
               
            }
             /*if (inventory_slot_exist == false){
                RectTransform InventoryRectTransform = Instantiate(access_inventory, quick_access_container).GetComponent<RectTransform>();
                InventoryRectTransform.gameObject.SetActive(true);
                InventoryRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                inventory_slot_exist = true;
            }*/
            
        }
        
    }

    private void add_inventory_slot(){
        RectTransform InventoryRectTransform = Instantiate(access_inventory, access_inventory_container).GetComponent<RectTransform>();
        InventoryRectTransform.gameObject.SetActive(true);
        InventoryRectTransform.anchoredPosition = new Vector2(-17, 0);
    }

}
