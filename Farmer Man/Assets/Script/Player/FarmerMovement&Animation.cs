using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerMovement : MonoBehaviour
{
    public float moveSpeed;   
    public float lastHorizontalVector;
    public float lastVerticalVector;
    public Vector2 lastMovedVector;
    public Vector2 hadap;
    Animator animator;
    SpriteRenderer sr;

    Rigidbody2D rb;
    PlayerStats player;


    void Start()
    {
        //Pengambilan Komponen
        player = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lastMovedVector = new Vector2(1, 0f);
    }

    void Update()
    {
        //Function
        InputManagement();
        Move();
        SpriteDirectionChecker();

        //Animasi
        if (hadap.x !=0 || hadap.y !=0)
        {
            animator.SetBool("Move", true);    
        }
        else
        {   
            animator.SetBool("Move", false);
        }


    }

    void Move()
    

    {
        //Gerak
        rb.velocity = new Vector2 (hadap.x * player.currentMoveSpeed, hadap.y * player.currentMoveSpeed);
    }

    void InputManagement()
    {
        
        if(hadap.x !=0)
        {
            lastHorizontalVector = hadap.x;
            lastMovedVector = new Vector2 (lastHorizontalVector, 0f);
        }

        if(hadap.y !=0)
        {
            lastVerticalVector = hadap.y;
            lastMovedVector = new Vector2 (0f, lastVerticalVector);
        }

        if(hadap.x != 0 && hadap.y != 0)
        {
            lastMovedVector = new Vector3 (lastHorizontalVector, lastVerticalVector);
        }

        //Input AWSD
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        hadap = new Vector2 (dirX, dirY).normalized;

    }

        void SpriteDirectionChecker()
    {
        //Animasi Run Kiri dan Kanan
        if (lastHorizontalVector < 0)
        {
            sr.flipX = true;
        }

        else
        {
            sr.flipX = false;
        }
    }

}
