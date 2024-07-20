using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// redesigned to replace CharacterScriptableObject script.
/// This inputs all the stats of the character inside a struct that can be also used for passives.
/// This also changes the starting weapons variable from a GameObject to WeaponData
/// </summary>
[CreateAssetMenu(fileName = "Character Data", menuName = "2D Top-Down Rogue-Like/Character Data")]
public class CharacterData : ScriptableObject
{
    //[SerializeField] allows the ability for the inspector window in unity to view a private variable
    [SerializeField] Sprite icon;
    [SerializeField] new string name;
    [SerializeField] WeaponData startingWeapon;

    //setters and getters for each value
    public Sprite Icon
    {
        get => icon;
        private set => icon = value;
    }

    public string Name
    {
        get => name;
        private set => name = value;
    }

    public WeaponData StartingWeapon
    {
        get => startingWeapon;
        private set => startingWeapon = value;
    }

    [System.Serializable]
    public struct Stats
    {
        public float maxHealth;
        public float recovery;
        public float armor;
        [Range(-1, 10)] public float moveSpeed, might, area;
        [Range(-1, 5)] public float speed, duration;
        [Range(-1, 10)] public int amount;
        [Range(-1, 1)] public float cooldown;
        [Min(-1)] public float luck, growth, greed, curse;
        public float magnet;
        public int revival;

        //allows the ability to use + to add stats together when wanting to increase character stats stats
        public static Stats operator +(Stats s1, Stats s2) 
        {
            s1.maxHealth += s2.maxHealth;
            s1.recovery += s2.recovery;
            s1.armor += s2.armor;
            s1.moveSpeed += s2.moveSpeed;
            s1.might += s2.might;
            s1.area += s2.area;
            s1.speed += s2.speed;
            s1.duration += s2.duration;
            s1.amount += s2.amount;
            s1.cooldown += s2.cooldown;
            s1.luck += s2.luck;
            s1.growth += s2.growth;
            s1.greed += s2.greed;
            s1.curse += s2.curse;
            s1.magnet += s2.magnet;
            return s1;
        }
    }

    //object initializer to set default values without constructor
    public Stats stats = new Stats
    {
        maxHealth = 100, moveSpeed = 5, might = 1, amount = 0,
        area = 1, speed = 1, duration = 1, cooldown = 1,
        luck = 1, greed = 1, growth = 1, curse = 1
    };
}