using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    float currentCooldown;
    protected FarmerMovement pm;
    protected virtual void Start()
    {
        pm = FindObjectOfType<FarmerMovement>();
        currentCooldown = weaponData.CooldownDuration;
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f)
        {
            Attack();   
        }
    }
        protected virtual void Attack()
        {
            currentCooldown = weaponData.CooldownDuration;
        }
    }
