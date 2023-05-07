using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public static Spawner instance;

    [SerializeField] private List<Coins> coins_list;
    [SerializeField] private int coins_amount = 30;
    [SerializeField] private Coins coin_reference;

    [SerializeField] private List<Enemy> enemies_list;


    

    
    [SerializeField] private CoinsCounterAndUpgradeManager coins_and_upgrades_manager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int index = 0; index < coins_amount; index++)
        {
            Coins coin = Instantiate(coin_reference);
            coin.prefab.SetActive(false);
            coins_list.Add(coin);
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public Coins GetPoolCoin()
    {
        for (int index = 0; index < coins_list.Count; index++)
        {
            if (!coins_list[index].isActiveAndEnabled)
            {
                return coins_list[index];
            }
        }
        return null;
    }


    public class Enemy : IEnemy
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] Vector2 spawn_location;

        public Enemy(Vector2 location)
        {
            Instantiate(prefab, new Vector3(location.x, 0.0f, location.y), Quaternion.identity);
        }
    }
}
   