using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Build_Controller : MonoBehaviour
{
   public RuleTile dirtTile;
   public Tilemap groundTileMap;

   public float castDistance = 1.0f;
   public Transform raycastPoint;
   public LayerMask layer;

   float blockDestroyTime = 0;

   Vector3 direction;
   RaycastHit2D hit;

   bool destroyingBlock = false;
   bool placingBlock = false;

   void FixedUpdate(){
       if(Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.C)){
           RaycastDirection();
       }
   }

   void RaycastDirection(){
       if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
           direction.x = Input.GetAxis("Horizontal");
           direction.y = Input.GetAxis("Vertical");
       }

       hit = Physics2D.Raycast(raycastPoint.position, direction, castDistance, layer.value);

       Vector2 endpos = raycastPoint.position + direction;

       Debug.DrawLine(raycastPoint.position, endpos, Color.red);

       if (Input.GetKey(KeyCode.F)){
           if (hit.collider && !destroyingBlock){
               destroyingBlock = true;
               Debug.Log(hit.collider.gameObject.GetComponent<Tilemap>());
               Debug.Log(endpos);
               StartCoroutine(DestroyBlock(hit.collider.gameObject.GetComponent<Tilemap>(), endpos));
           }
       }

       if (Input.GetKey(KeyCode.C)){
           if (!hit.collider && !placingBlock){
               placingBlock = true;
               StartCoroutine(PlaceBlock(groundTileMap, endpos));
           }
       }

   }

   IEnumerator DestroyBlock(Tilemap map, Vector2 pos){
       yield return new WaitForSeconds(blockDestroyTime);
       pos.y = Mathf.Floor(pos.y);
       pos.x = Mathf.Floor(pos.x);
       map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);
       destroyingBlock = false;
   }

   IEnumerator PlaceBlock(Tilemap map, Vector2 pos){
       yield return new WaitForSeconds(0f);
       pos.y = Mathf.Floor(pos.y);
       pos.x = Mathf.Floor(pos.x);
       map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), dirtTile);
       placingBlock = false;
   }

}
