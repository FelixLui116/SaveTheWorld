using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem : MonoBehaviour
{
    public static PoolSystem Instance { get; private set; }

    public GameObject playerAcre;

    public GameObject enemyAcre;


    private void Awake() {

        if (Instance == null)
        {
            Instance = this;
        }
    }     

    public void SpawnToPool(GameObject taegetObject , string tagName =  "Player" ){
        if (tagName == "Player" )
        {
            Instantiate (taegetObject, new Vector3(0,0,0) , Quaternion.identity , playerAcre.transform);
            
            // Instantiate(taegetObject , playerAcre.transform); //Bullet , transform.position = firePoint
        }
        else if(tagName == "Enemy"){
            
        } 
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
