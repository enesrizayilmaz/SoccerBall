using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f;
    public float jumpFrequency = 0f;
    public AudioSource zıplamasesi;
    public float nextJumptime;
    
    
    public bool isGrounded = true;
    public Transform groundCheckPosition;
    bool mouse;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        mouse = EventSystem.current.currentSelectedGameObject == null;
        HorizontalMove();
        OnGroundCheck();

        //Input.GetAxis("Vertical") > 0
        //Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && mouse && isGrounded && (nextJumptime <= Time.timeSinceLevelLoad ))
        {
            
            nextJumptime = Time.timeSinceLevelLoad + jumpFrequency;
            
            Jump();
        }




    }
  

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(4.9f*moveSpeed , playerRB.velocity.y);
       
        
        if (DataManager.Instance.Score > 25 && DataManager.Instance.Score <= 50)
        {
            playerRB.velocity = new Vector2(5.5f * moveSpeed, playerRB.velocity.y);
        }
        if (DataManager.Instance.Score > 50 && DataManager.Instance.Score <= 100)
        {
            playerRB.velocity = new Vector2(5.5f * moveSpeed, playerRB.velocity.y);
        }
        if (DataManager.Instance.Score > 100 && DataManager.Instance.Score <= 200)
        {
            playerRB.velocity = new Vector2(6.5f * moveSpeed, playerRB.velocity.y);
        }
        if (DataManager.Instance.Score > 200 && DataManager.Instance.Score <= 400)
        {
            playerRB.velocity = new Vector2(7f * moveSpeed, playerRB.velocity.y);
            
        }
    
        if (DataManager.Instance.Score > 400 && DataManager.Instance.Score <= 1000)
        {
            playerRB.velocity = new Vector2(8f * moveSpeed, playerRB.velocity.y);
            
}
        if (DataManager.Instance.Score > 1000 && DataManager.Instance.Score <= 2000) 
        {
            
            playerRB.velocity = new Vector2(10.1f * moveSpeed, playerRB.velocity.y);
        }
        if (DataManager.Instance.Score > 2000 && DataManager.Instance.Score <= 999999999)
        {

            playerRB.velocity = new Vector2(11f * moveSpeed, playerRB.velocity.y);
        }


    }
    void Jump()
    {

        playerRB.AddForce(new Vector2(0f, jumpSpeed));

        zıplamasesi.Play();

    }

    void OnGroundCheck()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
    }





}
