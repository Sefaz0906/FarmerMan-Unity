    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerStats : MonoBehaviour
    {
       public CharacterScriptableObject characterData;

        //Stats
        [HideInInspector]
        public float currentHealth;
        [HideInInspector]
        public float currentRecovery;
        [HideInInspector]
        public float currentMoveSpeed;
        [HideInInspector]
        public float currentMight;
        [HideInInspector]
        public float currentProjectileSpeed;
        [HideInInspector]
        public float currentMagnet;

        //Spawn Weapon
        public List<GameObject> spawnedWeapons;


        //Level Exp
        [Header("Experience/Level")]
        public int experience = 0;
        public int level = 1;
        public int experienceCap;

        [System.Serializable]
        public class LevelRange
        {
            public int startLevel;
            public int endLevel;
            public int experienceCapIncrease;
        }

        [Header ("I-Frames")]
        public float invincibilityDuration;
        float invincibilityTimer;
        bool isInvincible;

        public List<LevelRange> levelRanges;

        void Awake()
        {
            currentHealth = characterData.MaxHealth;
            currentRecovery = characterData.Recovery;
            currentMoveSpeed = characterData.MoveSpeed;
            currentMight = characterData.Might;
            currentProjectileSpeed = characterData.ProjectileSpeed;
            currentMagnet = characterData.Magnet;

            SpawnWeapon(characterData.StartingWeapon);
        }

        void Start()
    {
            experienceCap = levelRanges[0].experienceCapIncrease;
    }

        void Update()
        {
            if(invincibilityTimer > 0)
            {
                invincibilityTimer -= Time.deltaTime;
            }

            else if (isInvincible)
            {
                isInvincible = false;
            }

            Recover();
        }    


        //Take EXP
        public void IncreaseExperience(int amount)
        {
            experience += amount;

            LevelUpChecker();
        }

        void LevelUpChecker()
        {
            if(experience >= experienceCap)
            {
                level++;
                experience -= experienceCap;

                int experienceCapIncrease = 0;
                foreach (LevelRange range in levelRanges)
                {
                    if(level >= range.startLevel && level <= range.endLevel)
                    {
                        experienceCapIncrease = range.experienceCapIncrease;
                        break;
                    }
                }
                experienceCap += experienceCapIncrease;
            }
        }

        //Take Damage
        public void TakeDamage(float dmg)
        {
            if(!isInvincible)
            {
            currentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if(currentHealth <= 0)
            {
                Kill();
            }
            }

        }

        public void Kill()
        {
            Debug.Log("Player Is Death");
        }


        //Take Health Potion
        public void RestoreHealth(float tambah)
            {
                if(currentHealth < characterData.MaxHealth)
                {
                    currentHealth += tambah;

                    if(currentHealth > characterData.MaxHealth)
                    {
                    currentHealth = characterData.MaxHealth;
                    }
                }
            }
            void Recover()
            {
                if(currentHealth < characterData.MaxHealth)
                {
                    currentHealth += currentRecovery * Time.deltaTime;
                }

                else if(currentHealth == characterData.MaxHealth)
                {
                    currentHealth = characterData.MaxHealth;
                }
            }

            public void SpawnWeapon(GameObject weapon)
            {
                GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
                spawnedWeapon.transform.SetParent(transform);
                spawnedWeapons.Add(spawnedWeapon);
            }
    }
