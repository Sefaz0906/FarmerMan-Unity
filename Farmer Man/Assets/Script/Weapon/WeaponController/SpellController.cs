using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSpell = Instantiate(weaponData.Prefab);
        spawnedSpell.transform.position = transform.position;
        spawnedSpell.transform.parent = transform;
    }
}
