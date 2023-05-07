using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private MovementScipt player_movement;
    [SerializeField] private MouseLookScript player_look;
    [SerializeField] private CoinsCounterAndUpgradeManager coins_and_updates_manager;
    [SerializeField] private int rounded_coins;
    [SerializeField] private float actual_coins;
    [SerializeField] private TextMeshProUGUI coin_UI;


    public float GetCoins() => actual_coins;
    public float DisplayCoins()
    {
        return Mathf.Round(actual_coins);
    }
    public void SetCoins(float coins_number)
    {
        actual_coins += coins_number;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetCoins(100 * coins_and_updates_manager.coins_multiplier);
        }

        coin_UI.text = DisplayCoins().ToString();

        coins_and_updates_manager.coins_number = (int)actual_coins;

        player_movement.additional_jumps = coins_and_updates_manager.jumps_upgrades;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.body.tag == "JumpUP")
        {
            Debug.LogError("JumpUP");
            SetCoins(1 * coins_and_updates_manager.GetCoinsMultiplier());
        }
    }

    private void OnTriggerEnter(Collider other)
    {        
        other.GetComponentInParent<Upgrades>().OnTriggerEntered();        
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponentInParent<Upgrades>().OnTriggerExited();
    }

    public void BoughtItem(int price)
    {
        actual_coins -= price;
    }

}
