using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
public Transform player;

public bool flip = false;

void Update(){
    Vector3 flipped = transform.localScale;
    flipped.z *= -1f;

    if(transform.position.x > player.position.x && flip){
        transform.localScale = flipped;
        transform.Rotate(0f, 180f, 0f);
        flip = false;
    }

    else if(transform.position.x < player.position.x && !flip){
        transform.localScale = flipped;
        transform.Rotate(0f, 180f, 0f);
        flip = true;
    }
}
}
