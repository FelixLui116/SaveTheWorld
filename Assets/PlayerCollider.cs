using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private BaseCharacter baseCharacter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log(" in OnTriggerEnter: " + other.gameObject.tag);
        // Neet get parent
        if(other.gameObject.tag == "Coin"){
            Coin_trigger(other.transform.parent.gameObject);
        } 
        if(other.gameObject.tag == "Health"){

        } 
        if(other.gameObject.tag == "Ammo"){

        } 

        /// 

        if(other.gameObject.tag == "Weapon"){

            baseCharacter.WeaponGet(other.gameObject);
        } 
        // if(other.gameObject.tag == "Bullet"){

        // }
        
        // AudioPlayer(); 
        // DestroyItem();
    }

    private void Coin_trigger(GameObject obj ){
        
        Coin coin_obj = obj.GetComponent<Coin>();

        // AudioPlayer(); 
        // DestroyItem();
        Debug.Log(" Yes Get Coin: " + coin_obj.CoinNum);
    }


    private void OnCollisionEnter(Collision other) {
        
    }
}
