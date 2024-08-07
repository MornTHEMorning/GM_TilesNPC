using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    #region Variables
    public Rigidbody2D rb;
    public float movespeed;
    public InputAction playerInput;
    #endregion

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable(){
        playerInput.Enable();
    }
    private void OnDisable(){
        playerInput.Disable();
    }


    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    public void Update()
    {
        moveDirection = playerInput.ReadValue<Vector2>(); 
    }

    public void FixedUpdate(){
        rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y *movespeed);

    }

}
