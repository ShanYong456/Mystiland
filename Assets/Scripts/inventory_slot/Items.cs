using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Items
{
    public enum ItemType{
        Wooden_Pickaxe,//id:0
        Wooden_Axe,//id:1
        Dirt,//id:2
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite(){
       switch(itemType){
           default:
           case ItemType.Dirt:              return ItemsAssets.Instance.Dirt;
           case ItemType.Wooden_Pickaxe:    return ItemsAssets.Instance.Wooden_Pickaxe;
           case ItemType.Wooden_Axe:        return ItemsAssets.Instance.Wooden_Axe;
       } 
    }

    public bool IsStackable(){
        switch(itemType){
            default:
            case ItemType.Dirt:
                return true;
            case ItemType.Wooden_Pickaxe:
            case ItemType.Wooden_Axe:
                return false;
        }
    }
}
