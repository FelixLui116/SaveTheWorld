using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem : MonoBehaviour
{
    public static PoolSystem Instance { get; private set; }

    public GameObject playerAcre;
    public GameObject enemyAcre;
    public GameObject skillAcre;
    public GameObject DestroyAcre;

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

            taegetObject.tag = "EnemyHit";
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

    public GameObject CreatePoolSkill_top(Transform targetTF ,GameObject taegetObject ){

        GameObject obj_top = new GameObject();
        obj_top.transform.SetParent(skillAcre.transform);
        obj_top.name = "obj_top";
        obj_top.transform.rotation = targetTF.rotation;
        obj_top.transform.position = targetTF.position;
        
        var skillobj = Instantiate(taegetObject ,obj_top.transform );

        return obj_top;
    }

    public void MoveToDestroyPool(GameObject obj  ){
        obj.transform.SetParent(DestroyAcre.transform);
    }

    // public GameObject CreatePoolSkill(GameObject taegetObject, Transform targetTF , Vector3 addPosV3){

    //     GameObject obj_top = new GameObject();
    //     obj_top.transform.SetParent(skillAcre.transform);
    //     obj_top.name = "obj_top";
    //     GameObject parent = obj_top;

    //     parent.transform.rotation = targetTF.rotation;
    //     parent.transform.position = targetTF.position;
        
    //     // obj.transform.SetParent(skillAcre.transform);
    //     // return obj;
    //     return obj_top;

    // }
    // public void CreateTopSkillObj(GameObject taegetObject , GameObject obj) {
    //     GameObject obj_top = new GameObject();
    //     GameObject obj = Instantiate (taegetObject, targetV3 , Quaternion.identity (Quaternion.Euler(0, 0, 0) ), skillAcre.transform);
    //     obj_top.transform.SetParent(skillAcre.transform);
    //     obj_top.name = "obj_top";
        
    //     return obj_top;
    // }







    // public GameObject CreatePoolSkill(GameObject taegetObject, Transform targetTF , Vector3 addPosV3 ,GameObject parent ){

    //     // var x = targetTF.rotation.x;
    //     // var y = targetTF.rotation.y;
    //     // var z = targetTF.rotation.z;

    //     // Vector3 targetV3  = targetTF.position;
    //     // if (addPosV3 != null)
    //     // {
    //         // targetV3.x += addPosV3.x; 
    //         // targetV3.y += addPosV3.y; 
    //         // targetV3.z += addPosV3.z;
    //     // }
    //     parent.transform.rotation = targetTF.rotation;
    //     parent.transform.position = targetTF.position;


    //     // GameObject obj = Instantiate (taegetObject, targetV3 , Quaternion.identity (Quaternion.Euler(x, y, z) ), skillAcre.transform);
    //     GameObject obj = Instantiate (taegetObject, parent.transform);
    //     obj.tag = "PlayerHit";
    //     // obj.transform.position;
    //     obj.transform.position = new Vector3(0,0,0);
    //     Debug.Log("~~~ "+obj.transform.position.x);

    //     // obj.transform.SetParent(skillAcre.transform);
    //     return obj;

    // }

    // public GameObject CreateTopSkillObj() {

    //     GameObject obj_top = new GameObject();
    //     obj_top.transform.SetParent(skillAcre.transform);
    //     obj_top.name = "obj_top";
        
    //     return obj_top;
    // }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
