using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Pickup, ICollectible
{
    public int healthRestore;

    public void Collect()
    {
        Debug.Log("Called");
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.RestoreHealth(healthRestore);
    }
}


