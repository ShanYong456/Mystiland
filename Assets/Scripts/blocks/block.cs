using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class block : MonoBehaviour
{
    public Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void MakeDot (Vector3 Pos){
        Vector3Int cellPosition = tilemap.WorldToCell(Pos);
        tilemap.SetTile(cellPosition, null);
        //Debug.Log("X: "+overCollider2d.transform.position.x);
        //Debug.Log("Y: "+overCollider2d.transform.position.y);
        var type = gameObject.tag;
        //collectable_items.SpawnCollectableItems(new Vector3(Pos.x, Pos.y), new Items {itemType = Items.(ItemType)2, amount = 1});
        collectable_items.SpawnCollectableItems(new Vector3(Pos.x, Pos.y), new Items {itemType = Items.ItemType.Dirt, amount = 1});
    }

}
