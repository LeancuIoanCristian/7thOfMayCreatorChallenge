using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradesManager", menuName ="UpgradesManaager")]
public class CoinsCounterAndUpgradeManager : ScriptableObject
{
    [SerializeField] public int coins_number = 0;
    [SerializeField] public  float coins_multiplier = 1f;
    [SerializeField] public int jumps_upgrades = 0;
    [SerializeField] private int health_upgrades = 0;
    [SerializeField] private int damage_upgrades = 0;


    public float GetCoinsMultiplier() => coins_multiplier;
}
