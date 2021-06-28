using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quick_access
{
    public event EventHandler OnQuickAccessListChanged;
    private List<Items> QuickAccessList;

    public quick_access(){
        QuickAccessList = new List<Items>();
        
    }

    public void AddQuickAccess(Items item){
        if (GetQuickAccessList().Count < 7){
            if (item.IsStackable()){
            bool itemAlreadyInQuickAccess = false;
            foreach(Items QuickAccessItem in QuickAccessList){
                if (QuickAccessItem.itemType == item.itemType){
                    QuickAccessItem.amount += item.amount;
                    itemAlreadyInQuickAccess = true;
                }
            }
            if(!itemAlreadyInQuickAccess){
                QuickAccessList.Add(item);
            }
            }else{
                QuickAccessList.Add(item);
            }
        }
        OnQuickAccessListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Items> GetQuickAccessList(){
        return QuickAccessList;
    }
}
