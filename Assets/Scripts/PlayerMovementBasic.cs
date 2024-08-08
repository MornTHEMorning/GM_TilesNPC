using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player{
public class PlayerMovement : MonoBehaviour
{

//The goal: https://www.youtube.com/watch?v=YnwOoxtgZQI - tile based travel
//The basic understanding: https://www.youtube.com/watch?v=HmXU4dZbaMw - how to use input based system

    #region Variables
    public Rigidbody2D rb;
    public float movespeed;
    public InputAction playerInput;
    private Vector2 moveDirection; 
    #endregion

    private void OnEnable(){
        playerInput.Enable();
    }
    private void OnDisable(){
        playerInput.Disable();
    }

    // Update is called once per frame
    public void Update()
    {
        moveDirection = playerInput.ReadValue<Vector2>();  //from video


    }

    public void FixedUpdate(){
        rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y *movespeed);

    }

}
}