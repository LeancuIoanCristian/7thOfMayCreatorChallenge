using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private PlayerManager player;
    [SerializeField] private List<Upgrades> upgrades;
    [SerializeField] private CoinsCounterAndUpgradeManager saved_upgrades;
    
   
   

    // Start is called before the first frame update
    void Start()
    {
        upgrades[0].cost_multiplier = saved_upgrades.jumps_upgrades + 1;
        upgrades[1].cost_multiplier = (int)(saved_upgrades.GetCoinsMultiplier() + 1f);
    }

    // Update is called once per frame
    void Update()
    {
        saved_upgrades.jumps_upgrades = upgrades[0].cost_multiplier - 1;
        saved_upgrades.coins_multiplier =  upgrades[1].cost_multiplier - 1;
    }

  
}
  