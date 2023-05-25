using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb; 
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    private void Awake() 
    {
        playerControls = new PlayerControls();  
        rb = GetComponent<Rigidbody2D>();  
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
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
        AdjustPlayerFacingDirection();
        Move();
    }
    /*private void OnDisable() {
        playerControls.Disable();    
    }*/

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();   //read value of movement action in Action Map

        //Debug.Log(movement.x);

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            // flip the player sprite
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }
}
