using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural_Generation : MonoBehaviour
{
    [SerializeField] int width, max_height, depth;
    [SerializeField] GameObject dirt_with_grass, dirt;
    [SerializeField] RuleTile dirt_rule;
    [SerializeField] UnityEngine.Tilemaps.Tilemap tilemap;


    void Start()
    {
        Generation();
    }

    void Generation()
    {
        //float minHeight = 2 * (height - 1);
        //float maxHeight = 2 * (height + 2);
        //This will help to spawn a tile on the x axis
        float x_value = 0.00f;
        float y_value = 0.00f;
        int new_width = width/2;
        float height = 0.00f;
        float check_height = 0.00f;
        bool smooth_check = false;
        //generate on the positive x-axis (right side of the map) 
        for (int x = 0; x < new_width; x++){
            if (x < 3){
                //to ensure the starting grounds is always flat for player
                 
                 spawnObj(dirt_with_grass, x-x_value, 0);
                 //tilemap.SetTile(new Vector3Float(x-x_value, 0, 0), dirt_rule);
                 //spawn_tile((x-x_value), 0, dirt_rule);
                  y_value = 0.5f;
                  for (int y = -1; y > (-1*depth); y--){
                        spawnObj(dirt,x-x_value, y+y_value);
                        //tilemap.SetTile(new Vector3Float(x-x_value, y+y_value, 0), dirt_rule);
                        //spawn_tile((x-x_value), (y+y_value), dirt_rule);
                        y_value += 0.5f;
                  }
                  check_height = 0;
                  x_value += 0.5f;
                 
            }else{
                smooth_check = false;
                while (smooth_check == false){
                    height = Random.Range(0, max_height);
                    if (Mathf.Abs(check_height - height) <= 1){
                        smooth_check = true;
                        check_height = height;
                    }
                    
                }
                spawnObj(dirt_with_grass, x-x_value, height / 2);
                //spawn_tile((x-x_value), (height/2), dirt_rule);
                for (float y = height-1; y >= 0; y--){
                    spawnObj(dirt, x-x_value, y/2);
                    //tilemap.SetTile(new Vector3Float(x-x_value, y/2, 0), dirt_rule);
                    //spawn_tile((x-x_value), (y/2), dirt_rule);
                }
                y_value = 0.5f;
                for (float y = -1; y > (-1*(depth)); y--){
                    spawnObj(dirt, x-x_value, y+y_value);
                    //tilemap.SetTile(new Vector3Float(x-x_value, y+y_value, 0), dirt_rule);
                    //spawn_tile((x-x_value), (y+y_value), dirt_rule);
                    y_value += 0.5f;
                }
                x_value += 0.5f;

            }

            
                
        }
        x_value = 0.00f;
        //generate on the negative x-axis (left side of the map) 
        for (int x = -1; x > (-1*new_width); x--){
            if (x > -4){
                //to ensure the starting grounds is always flat for player
                x_value += 0.5f;
                 spawnObj(dirt_with_grass, x+x_value, 0);
                 //tilemap.SetTile(new Vector3Float(x+x_value, 0, 0), dirt_rule);
                 //spawn_tile((x+x_value), 0, dirt_rule);
                 y_value = 0.5f;
                 for (int y = -1; y > (-1*depth); y--){
                    spawnObj(dirt, x + x_value, y+y_value);
                    //tilemap.SetTile(new Vector3Float(x+x_value, y+y_value, 0), dirt_rule);
                    //spawn_tile((x+x_value), (y+y_value), dirt_rule);
                    y_value += 0.5f;
                 }
                 check_height = 0;
            }else{
                smooth_check = false;
                x_value += 0.5f;
                while (smooth_check == false){
                    height = Random.Range(0, max_height);
                    if (Mathf.Abs(check_height - height) <= 1){
                        smooth_check = true;
                        check_height = height;
                    }
                    
                }
                spawnObj(dirt_with_grass, x+x_value, height / 2);
                //tilemap.SetTile(new Vector3Float(x+x_value, height/2, 0), dirt_rule);
                //spawn_tile((x+x_value), (height/2), dirt_rule);
                for (float y = height-1; y >= 0; y--){
                    spawnObj(dirt, x+x_value, y/2);
                    //tilemap.SetTile(new Vector3Float(x+x_value, y/2, 0), dirt_rule);
                    //spawn_tile((x+x_value), (y/2), dirt_rule);
                }
                y_value = 0.5f;
                for (float y = -1; y > (-1*(depth)); y--){
                    spawnObj(dirt, x+x_value, y+y_value);
                    //tilemap.SetTile(new Vector3Float(x+x_value, y+y_value, 0), dirt_rule);
                    //spawn_tile((x+x_value), (y+y_value), dirt_rule);
                    y_value += 0.5f;
                }
                
            }
                
        }

    }

    //Whatever we spawn will be a child of our procedural generation gameObject
    void spawnObj(GameObject obj, float width, float height){
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;

       
    }

    void spawn_tile(float x_value, float y_value, RuleTile tile){
        //Vector3Int newPos = new Vector3Int(Mathf.RoundToInt(x_value - 0.5f),Mathf.RoundToInt(y_value - 0.5f),0);
        //tilemap.SetTile(newPos, tile);
        tilemap.SetTile(new Vector3Int(Mathf.RoundToInt(x_value - 0.5f),Mathf.RoundToInt(y_value - 0.5f),0), tile);
    }


}
