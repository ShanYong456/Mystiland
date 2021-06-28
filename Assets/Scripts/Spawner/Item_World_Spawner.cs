using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_World_Spawner : MonoBehaviour
{
    public Items item;

    private void Start(){
        collectable_items.SpawnCollectableItems(transform.position, item);
        Destroy(gameObject);
    }
}
