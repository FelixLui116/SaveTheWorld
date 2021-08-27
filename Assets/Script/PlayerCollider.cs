using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollider : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityAction ApplyChangeHPAction;
    public UnityAction ApplyChangeCoinAction;
    [SerializeField] private PlayerCharacterController playerCharacterController;
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
            // playerCharacterController.WeaponGet(other.gameObject);

            // playerCharacterController.baseGun.PopupGunInfo();
            Debug.Log("=== Trigger Weapon");
            playerCharacterController.WeaponGet_Select(other.gameObject);
        } 
        // if(other.gameObject.tag == "Bullet"){

        // }
        if(other.gameObject.tag == "EnemyHit"){
            PlayerGetHit(other.transform.parent.gameObject);
        } 
        
        // AudioPlayer(); 
        // DestroyItem();
    }


    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Weapon"){
            Debug.Log("=== TriggerExit Weapon");
            playerCharacterController.WeaponTriggerExit();

            BaseGun baseGun = other.gameObject.GetComponent<BaseGun>();
            baseGun.ClosePopupGunInfo();
            // playerCharacterController.baseGun.PopupGunInfo();
        } 
    }

    private void Coin_trigger(GameObject obj ){
        
        Coin coin_obj = obj.GetComponent<Coin>();
        
        // AudioPlayer(); 
        // DestroyItem();
        playerCharacterController.Coin += coin_obj.CoinNum;
        
        ApplyChangeCoinAction?.Invoke();
        Debug.Log(" Yes Get Coin: " + coin_obj.CoinNum + " || "+ playerCharacterController.Coin );
    }

    private void Health_trigger(GameObject obj ){
        
        MedKit MedKit_obj = obj.GetComponent<MedKit>();

        if (  (playerCharacterController.Current_health + MedKit_obj.HealingNum) < playerCharacterController.Health_max )
        {
            playerCharacterController.Current_health += MedKit_obj.HealingNum; 
        }

        ApplyChangeHPAction?.Invoke();

        Debug.Log(" Yes Get Health_: " + MedKit_obj.HealingNum + " || "+ playerCharacterController.Current_health );

    }
    private void Ammo_trigger(GameObject obj ){
        
        AmmoBox Ammo_obj = obj.GetComponent<AmmoBox>();
        Debug.Log(" Yes Get Ammo: " +Ammo_obj.ammoTpye + " ||Num: "+Ammo_obj.AmmoNum);
        // playerCharacterController.baseGun.AddAmmoTpye(Ammo_obj.ammoTpye, Ammo_obj.AmmoNum ); // Ammo_obj.AmmoNum;
    }
    private void PlayerGetHit(GameObject obj ){
        // playerCharacterController.Current_health -= 10;
        Projectile projectile = obj.GetComponent<Projectile>();
        playerCharacterController.Current_health -=  (int)projectile.bulletDamage;
        Debug.Log("=== : " + projectile.canPassThrough_bullet);
        if (!projectile.canPassThrough_bullet){
            projectile.DestroyObj();
        }

        ApplyChangeHPAction?.Invoke();
        
    }

    private void OnCollisionEnter(Collision other) {   
        Debug.Log("==== :" +other);
    }
}
