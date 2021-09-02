using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCharacterController : BaseCharacter
{
    private bool isPlayer = false;
    private void Awake() {
        
    }
    void Start()
    {
        
        targetPlayer = LevelController.Instance.playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        // DetectTarget();
    }
    private void OnTriggerEnter(Collider other) {
        // Neet get parent
        if (!isPlayer)
        {
            if(other.gameObject.tag == "Player"){
                Debug.Log("is Player~~~");
                isPlayer = true;
            } 
        }
        
        
    }
    private void OnTriggerExit(Collider other) {
        // Neet get parent
        if (isPlayer)
        {
            if(other.gameObject.tag == "Player"){
                Debug.Log("Not Player~~~");
                isPlayer = false;
            } 
        }
    }

    // private void DetectTarget(){
    //     Vector3 targetPlayer_V3  = new Vector3(targetPlayer.position.x ,targetPlayer.position.y , targetPlayer.position.z );
    //     Vector3 thisObj_V3 = new Vector3( transform.position.x ,transform.position.y , transform.position.z);

    //     if(Vector3.Distance(thisObj_V3, targetPlayer_V3) < DetectRange)
    //     {
    //         //Do something
    //         detected_Target = true;
    //         Debug.Log(" Is Player- NPC");
    //         // CurrentState = EnemyState.GetTarget;   // movePath.StopCoroutines();
    //         // movePath.Base_moveToTarget( targetPlayer );

    //     }else{
    //         detected_Target = false;
    //         // CurrentState = EnemyState.Idle;
    //     }
    // } 

}
