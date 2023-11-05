using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehavior
{

    protected override void Start()
    {
        base.Start();
    }

    
    void Update()
    {
        transform.position += direction * currentSpeed * Time.deltaTime;     
    }
}
