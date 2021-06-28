using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAssets : MonoBehaviour
{
    public static ItemsAssets Instance {get; private set;}

    private void Awake(){
        Instance = this;
    }

    public Transform Prefab_Collectable_Items;

    public Sprite Wooden_Pickaxe;
    public Sprite Wooden_Axe;
    public Sprite Dirt;
}
