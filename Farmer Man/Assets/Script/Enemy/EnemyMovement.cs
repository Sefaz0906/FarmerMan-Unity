using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyStats enemy;
    Transform player;
    SpriteRenderer sr;

    void Start()
    {
        enemy = GetComponent<EnemyStats>();
        sr = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<FarmerMovement>().transform;
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);
    }
}
