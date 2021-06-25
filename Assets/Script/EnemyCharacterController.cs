using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterController : BaseCharacter
{
    //  transform.LookAt(target);

    [SerializeField] protected float moveMaxRange = 50f;
    private Vector3 pos;
    [SerializeField] private float MoveSpeed = 1f;      // in time // 一定時間內完成
    [SerializeField] private float RotateSpeed = 5f;    // in time // Roatate in X sec  一定時間內完成

    [SerializeField] private GameObject thisObj; 
    [SerializeField] private float Forward = 10f;
    protected bool IsMoving = false;
    protected bool IsGettarget = false;

    void Start()
    {
        pos = this.transform.position;
        thisObj = this.gameObject;

        Debug.Log("Enemy MoveMaxRange x = " + pos.x  +" || z: " + pos.z);
        
        // Base_Behaviour();
        // RandomMovment();
        MovingForward();
        // StartCoroutine( Move_func( new Vector3(0,0,0) ,  MoveSpeed ) );
        StartCoroutine(Rotate_func(Vector3.down * 180, 5f) ); //down: Vector3(0, -1, 0).
    }

    void Update()
    {
        
    }

    private void MoveCharacter(int Move_status , Vector3 MovePos){
        switch (Move_status)
        {
        case 5:
            Debug.Log("");
            break;
        case 4:
            Debug.Log("Rotate , back 180");
            StartCoroutine(Rotate_func(Vector3.down * 180, RotateSpeed) ); //down: Vector3(0, -1, 0).
            break;
        case 3:
            Debug.Log("Rotate , right 90");
            StartCoroutine(Rotate_func(Vector3.down * -90, RotateSpeed) ); //down: Vector3(0, -1, 0).
            break;
        case 2:
            Debug.Log("Rotate , left 90");
            StartCoroutine(Rotate_func(Vector3.down * 90, RotateSpeed) ); //down: Vector3(0, -1, 0).
            break;
        case 1:
            Debug.Log("stop");
            IsMoving = false;
            break;
        default:
            Debug.Log("move forward");
            StartCoroutine( Move_func( MovePos , MoveSpeed) );
            break;
        }
    }

    

    public void Base_Behaviour(  ){
        
        
    }

    public void RandomMovment ( ){
        Vector3 targetPosition = new Vector3();
        targetPosition = pos;

        var _moveMaxRange = moveMaxRange/2;
        Debug.Log( "=" +_moveMaxRange);
        var RandomRange_X = Random.Range( -_moveMaxRange, _moveMaxRange); // /2 Because Range doble  
        var RandomRange_Z = Random.Range( -_moveMaxRange, _moveMaxRange);
        
        targetPosition.x += RandomRange_X;
        targetPosition.z += RandomRange_Z;

        Debug.Log("=== " + pos + " || "+ targetPosition );
        //         while ( !(Vector3.Distance(pos, targetPosition) < moveMaxRange) )
        //         {
        //             Debug.Log(" in range ");
        //         }
        // Debug.Log(" out of range ");

        // Ranodom 
        if(Vector3.Distance(pos, targetPosition) < moveMaxRange){
            Debug.Log(" in range ");
            StartCoroutine( Move_func( targetPosition,  MoveSpeed ) );

        }else{
            Debug.Log(" out of range ");
            Base_Behaviour( );
        }
        /// 
    }

    public void MovingForward ( ){
        Vector3 targetPosition = new Vector3();
        targetPosition = pos;
        
        targetPosition.z += Forward;

        Debug.Log("=== " + pos + " || "+ targetPosition );
        //         while ( !(Vector3.Distance(pos, targetPosition) < moveMaxRange) )
        //         {
        //             Debug.Log(" in range ");
        //         }
        // Debug.Log(" out of range ");

        // Ranodom 
        if(Vector3.Distance(pos, targetPosition) < moveMaxRange){
            Debug.Log(" in range ");
            StartCoroutine( Move_func( targetPosition,  MoveSpeed ) );

        }else{
            Debug.Log(" out of range ");
            Base_Behaviour( );
        }
        /// 
    }
    
    
    //  ////Test Func
    public void Test_func(){
        StartCoroutine( Move_func( new Vector3(0, 1.6f ,0) ,  MoveSpeed ) );
        Debug.Log("Pos: " +pos);
        thisObj.transform.position =  pos ;
    }
}
