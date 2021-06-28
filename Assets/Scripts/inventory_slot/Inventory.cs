using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    private List<Items> itemList;

    public Inventory(){
        itemList = new List<Items>();
        
    }

    public void AddItem(Items item){
        if (item.IsStackable()){
            bool itemAlreadyInInventory = false;
            foreach(Items inventoryItem in itemList){
                if (inventoryItem.itemType == item.itemType){
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if(!itemAlreadyInInventory){
                itemList.Add(item);
            }
        }else{
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Items> GetItemList(){
        return itemList;
    }
}
