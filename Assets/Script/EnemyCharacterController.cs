using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterController : BaseCharacter
{
    //  transform.LookAt(target);

    [SerializeField] protected float moveMaxRange = 10;
    private Vector3 pos;

    void Start()
    {
        pos = this.transform.position;

        Debug.Log("Enemy MoveMaxRange x = " + pos.x  +" || z: " + pos.z);
    }

    void Update()
    {
        
    }

    public void Base_Behaviour( float delayTimer = 2.0f , float MoveTime = 1.0f ){
        Vector3 tagetPosition = new Vector3();
        var RandomRange = Random.Range(-10.0f, 10.0f);

        tagetPosition.x += RandomRange;
        tagetPosition.z += RandomRange;

        // while ()
        // {
            
        // }

        if(Vector3.Distance(pos, tagetPosition) < moveMaxRange){
            Debug.Log(" in range ");
        }else{
            Debug.Log(" out of range ");
        }
    }

    

    public void Movement(Vector3 tagetPos){
        
    }
    
}
