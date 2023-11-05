using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    private float speed;
    private float lastHorizontalVector;
    private Vector2 hadap;
    private Vector3 direction;
    SpriteRenderer sr;


    void Start()
    {
        //Pengambilan Komponen
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Function
        AmbilInput();
        Move();
        SpriteDirectionChecker();
    }

    void Move()
    {
        //Gerak
        transform.Translate(hadap * speed * Time.deltaTime);
    }

    void AmbilInput()
    {
        //Input AWSD
        hadap = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
             hadap += Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            hadap += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            hadap += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            hadap += Vector2.right;
        }

        if (hadap.magnitude > 1)
        {
            hadap.Normalize();
        }

    }

    public void priteDirectionCheckerS(Vector3 dir)
    {

        direction = dir;

        float dirX = direction.x;
        float dirY = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirX < 0 && dirY == 0)
        {
            scale.x = scale.x * -1;
        }

    }

   public void SpriteDirectionChecker()
    {
        //Animasi Run Kiri dan Kanan
        if(hadap.x !=0)
        {
            lastHorizontalVector = hadap.x;
        }

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
