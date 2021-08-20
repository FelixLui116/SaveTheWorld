using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCollider : MonoBehaviour
{
    public UnityAction ApplyChangeHPAction;
    [SerializeField] private BaseCharacter enemyCharacter;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log(" in OnTriggerEnter: " + other.gameObject.tag);
        // Neet get parent
        if(other.gameObject.tag == "Coin"){
        } 
        if(other.gameObject.tag == "Health"){
        } 
        if(other.gameObject.tag == "Ammo"){
        } 
        if(other.gameObject.tag == "Weapon"){
        } 
        // if(other.gameObject.tag == "Bullet"){

        // }
        if(other.gameObject.tag == "PlayerHit"){
            EnmeyGetHit(other.transform.parent.gameObject);
        } 
        
        // AudioPlayer(); 
        // DestroyItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void EnmeyGetHit(GameObject obj ){
        // baseCharacter.Current_health -= 10;
        Projectile projectile = obj.GetComponent<Projectile>();
        if (projectile.canPassThrough_bullet){
            projectile.DestroyObj();
        }
        enemyCharacter.Current_health -=  (int)projectile.bulletDamage;

        ApplyChangeHPAction?.Invoke();
    }
}
