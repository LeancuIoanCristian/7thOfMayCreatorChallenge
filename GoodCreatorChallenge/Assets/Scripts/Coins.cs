using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] public GameObject prefab;
    [SerializeField] Vector3 spawn_location;
    [SerializeField] float multiplier;
    [SerializeField] Collider coin_collider;

    public void CoinsGenerate(Vector3 location, GameObject coin_prefab, float coin_multiplier)
    {
        
        Instantiate(coin_prefab, location, coin_prefab.transform.rotation);
        prefab = coin_prefab;
        multiplier = coin_multiplier;
    }

    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.body.tag == "Player")
        {
            Debug.LogWarning("Coin Touched player");
            collision.body.GetComponent<PlayerManager>().SetCoins(1 * multiplier);
            prefab.SetActive(false);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
