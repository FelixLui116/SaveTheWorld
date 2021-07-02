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
            Health_trigger(other.transform.parent.gameObject);
        } 
        if(other.gameObject.tag == "Ammo"){
            Ammo_trigger(other.transform.parent.gameObject);
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
        baseCharacter.Coin += coin_obj.CoinNum;
    }

    private void Health_trigger(GameObject obj ){
        
        MedKit MedKit_obj = obj.GetComponent<MedKit>();
        Debug.Log(" Yes Get Health_: " +MedKit_obj );

        baseCharacter.Current_health += MedKit_obj.HealingNum;
    }
    private void Ammo_trigger(GameObject obj ){
        
        AmmoBox Ammo_obj = obj.GetComponent<AmmoBox>();
        Debug.Log(" Yes Get Ammo: " +Ammo_obj.ammoTpye + " ||Num: "+Ammo_obj.AmmoNum);
        // baseCharacter.baseGun.AddAmmoTpye(Ammo_obj.ammoTpye, Ammo_obj.AmmoNum ); // Ammo_obj.AmmoNum;
    }

    private void OnCollisionEnter(Collision other) {
        
    }
}
