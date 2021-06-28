using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float MovementSpeed = 1;

    public float JumpForce = 1;

    private Rigidbody2D _rigidbody;

    public Animator animator;

    public LayerMask groundLayer;

    private Inventory inventory;

    private quick_access quick_access;

    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private quick_access_slots uiQuickAccess;

    /*private void Awake(){
        //inventory = new Inventory();
        //uiInventory.SetInventory(inventory);
    }*/
 
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        inventory = new Inventory();
        quick_access = new quick_access();
        uiInventory.SetInventory(inventory);
        uiQuickAccess.SetQuickAccess(quick_access);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown ("right") || Input.GetKeyDown (KeyCode.D)) {
         transform.eulerAngles = new Vector3(0, 0 ,0);
        }

        if (Input.GetKeyDown ("left") || Input.GetKeyDown (KeyCode.A)) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

         var movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement));
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if ((Input.GetKeyDown("space") || Input.GetKeyDown (KeyCode.W)) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {  
             animator.SetBool("Jump", true);
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }else if (_rigidbody.velocity.y == 0){
            animator.SetBool("Jump", false);
       }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        collectable_items collectable_items = collider.GetComponent<collectable_items>();
        if (inventory.GetItemList().Count < 20){
            if (collectable_items != null){
                //Touching Item
                inventory.AddItem(collectable_items.GetItem());
                quick_access.AddQuickAccess(collectable_items.GetItem());
                collectable_items.DestroySelf();
            }
        }
        
        
    }
}
