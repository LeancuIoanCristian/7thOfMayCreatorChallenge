using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Upgrades : MonoBehaviour
{
    [SerializeField] private PlayerManager player_manager_reference;
        [SerializeField] public string upgrade_name;
        [SerializeField] public int number_of_upgrades;
        [SerializeField] public int cost_multiplier;
        [SerializeField] public GameObject prefab;
        [SerializeField] public TextMeshProUGUI interaction_text;
        [SerializeField] public TextMeshProUGUI cost_text;
        private int cost = 10;
        private bool shopping = false;

    private void Start()
    {
        cost_text.text = (cost * cost_multiplier * number_of_upgrades).ToString();
    }
    private void Update()
    {
        cost_text.text = (cost * cost_multiplier * number_of_upgrades).ToString();

        if (shopping && Input.GetKeyDown(KeyCode.E))
        {
            if (player_manager_reference.GetCoins() > cost * cost_multiplier * number_of_upgrades + cost_multiplier * number_of_upgrades)
            {
                player_manager_reference.BoughtItem(cost * cost_multiplier * number_of_upgrades);
                number_of_upgrades++;
                cost_multiplier++;
                
            }
        }
    }

    public void OnTriggerEntered()
    {
           
        interaction_text.text = "Press E to buy";
        shopping = true;
            
    }
    public void OnTriggerExited()
    {
        interaction_text.text = " ";
        shopping = false;

    }

   
            
   
    public void Touched()
    {
        Debug.LogError("Auch");
    }
}
