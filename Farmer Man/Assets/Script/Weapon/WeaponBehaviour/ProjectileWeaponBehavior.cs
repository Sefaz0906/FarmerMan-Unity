using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehavior : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;
    public WeaponScriptableObject weaponData;

    //Stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
        // base.Start();
    }

    // Update is called once per frame
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
        }
    }
}
