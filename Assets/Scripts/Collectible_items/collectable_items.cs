using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectable_items : MonoBehaviour
{

  public static collectable_items SpawnCollectableItems(Vector3 position, Items item){
      Transform transform = Instantiate(ItemsAssets.Instance.Prefab_Collectable_Items, position, Quaternion.identity);
      collectable_items collectable_items = transform.GetComponent<collectable_items>();
      collectable_items.SetItem(item);

      return collectable_items;
  }

  private Items item;
  private SpriteRenderer SpriteRenderer;
  private TextMeshPro TextMeshPro;

  private void Awake() {
      SpriteRenderer = GetComponent<SpriteRenderer>();
      TextMeshPro = transform.Find("amount_text").GetComponent<TextMeshPro>();
  }

  public void SetItem (Items item) {
      this.item = item;
      SpriteRenderer.sprite = item.GetSprite();
      if (item.amount > 1){
          TextMeshPro.SetText(item.amount.ToString());
      }else{
          TextMeshPro.SetText("");
      }
  }

  public Items GetItem(){
      return item;
  }

  public void DestroySelf(){
      Destroy(gameObject);
  }

}

