using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BaseItem
{
    [Range(0, 1000)] public int CoinNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("=== " + DestroyTime);
        // audio_Collision.clip = ResourcesAudio.Instance.coin;
    }

    // protected override void OnCollisionEnter(Collision other){
    //     Debug.Log(" in Coin Collistion " + other.gameObject.name);
    //     // Add health to other(BaseCharater) -> levelController

    //     base.OnCollisionEnter(other);

    //     // add player Coin
    //     // baseCharacter._coin += CoinNum;
    // }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log(" in Coin OnTriggerEnter " + other.gameObject.name);
        
        if(other.gameObject.tag == "Player")
        {
            DestroyItem();
            AudioPlayer(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
