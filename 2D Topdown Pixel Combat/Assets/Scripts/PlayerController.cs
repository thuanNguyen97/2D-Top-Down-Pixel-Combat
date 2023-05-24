using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb; 

    private void Awake() 
    {
        playerControls = new PlayerControls();  
        rb = GetComponent<Rigidbody2D>();  
    }

    private void OnEnable() 
    {
        playerControls.Enable();
    }

    private void Update() 
    {
        PlayerInput();
    }

    private void FixedUpdate()  //good for handling the physic
    {
        Move();
    }
    /*private void OnDisable() {
        playerControls.Disable();    
    }*/

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();   //read value of movement action in Action Map

        //Debug.Log(movement.x);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

}
