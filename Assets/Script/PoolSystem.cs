using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem : MonoBehaviour
{
    public static PoolSystem Instance { get; private set; }

    public GameObject playerAcre;

    public GameObject enemyAcre;

    // public List<Projectile> bulletPoolList = new List<Projectile>();


    private void Awake() {

        if (Instance == null)
        {
            Instance = this;
        }
    }     

    
    public void SpawnToPool(GameObject taegetObject , string tagName =  "Player" , GameObject PoolAcre = null ){ // GameObject PoolAcre 
        if (tagName == "Player" )
        {
        taegetObject.tag = "PlayerHit";
            // taegetObject.tag = "PlayerBullet";
            Instantiate (taegetObject, new Vector3(0,0,0) , Quaternion.identity , PoolAcre.transform);
            
            // Instantiate(taegetObject , playerAcre.transform); //Bullet , transform.position = firePoint
        }
        else if(tagName == "Enemy"){
            // taegetObject.tag = "EnemyBullet";

        // taegetObject.tag = "EnemyHit";
            Instantiate (taegetObject, new Vector3(0,0,0) , Quaternion.identity , PoolAcre.transform);
        } 
    }

    public GameObject CreatePoolForBullet(string Holder , string poolName){
        Transform newParent;
        if (Holder == "Player"){
            newParent = playerAcre.transform;
        }
        else{
            newParent = enemyAcre.transform;
        }
        GameObject objPool = new GameObject();
        objPool.name = poolName + "_poolBullet";
        objPool.transform.SetParent(newParent);

        return objPool;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
