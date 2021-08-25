using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.Events;

public class MovePath : MonoBehaviour
{

    [SerializeField] private float MoveSpeed = 5f;      // in time // 一定時間內完成
    [SerializeField] private float RotateSpeed = 2f;    // in time // Roatate in X sec  一定時間內完成

    [SerializeField] private float waiting = 2f;
    [SerializeField] private float Forward = 10f;
    protected bool IsMoving = false;
    public bool IsloopPath = false;
    public CharacterController characterController;
    [SerializeField] private Transform thisObj; 

    [SerializeField] protected Transform[] Path;
    private int PathCount = 0;

    public UnityAction ApplyShoot;

    void Start()
    {
        // ToMove();
        // ToRotateTarget_test();
    }

    private void Update() {
        
    }

    public void ToMove(){
        if(Path.Length > 0){ //have more than one Path
            float moveV3_x = Path[PathCount].position.x;
            float moveV3_z = Path[PathCount].position.z;


            thisObj.DOLookAt(new Vector3(Path[PathCount].position.x, Path[PathCount].position.y, Path[PathCount].position.z), RotateSpeed , AxisConstraint.Y , Vector3.up);
    
            Tween t = thisObj.DOMove( new Vector3(moveV3_x, thisObj.position.y ,moveV3_z) , MoveSpeed);

            t.OnComplete( ()=> {
                PathCount++;
                // Debug.Log("PathCount: " +PathCount + " || "+Path.Length );
                if (PathCount >= Path.Length){
                    PathCount = 0;
                }
                ToMove();
            } );   
        } 
    }

    public void KillAllAction(){
        thisObj.DOKill();
    }

    public void ToRotate(){
        // thisObj.DoRotate(new Vector3(0,90,0) , RotateSpeed);
    }
    public void ToRotateTarget(Transform _target){
        
        Tween t = thisObj.DOLookAt(new Vector3(_target.position.x, _target.position.y, _target.position.z), RotateSpeed , AxisConstraint.Y , Vector3.up);
    
        t.OnComplete( ()=> {
            ApplyShoot?.Invoke();
        } );        
    }
    // public void ToRotateTarget_test (){
    //     transform.DORotate(new Vector3(0, 0, 360), 5);
    // }

}

    // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // [SerializeField] private float MoveSpeed = 5f;      // in time // 一定時間內完成
    // [SerializeField] private float RotateSpeed = 5f;    // in time // Roatate in X sec  一定時間內完成

    // [SerializeField] private float waiting = 2f;
    // [SerializeField] private float Forward = 10f;
    // protected bool IsMoving = false;
    // public bool IsloopPath = false;
    // public CharacterController characterController;
    // [SerializeField] private Transform thisObj; 

    // [SerializeField] protected Transform[] Path;
    // private int PathCount = 0;
    
    // private Vector3 thisObj_V3;
    // void Start()
    // {
    //     thisObj_V3 = new Vector3(thisObj.position.x ,thisObj.position.y , thisObj.position.z );

    //     // Testing
    //     // Vector3 path_V3 = new Vector3(Path[0].position.x , Path[0].position.y ,  Path[0].position.z );
    //     // StartCoroutine( Move_func(path_V3 , MoveSpeed ) );


    //     // StartCoroutine( PathGo() ); 
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // public void Base_moveToTarget( Transform targetPos  , bool Rotate = false, bool MoveTo = false){
    //     Debug.Log("--- Base_moveToTarget");
    //     StartCoroutine(  Rotate_func( targetPos ) );

    // }
    
    // public void RotateToTarget(Transform target){
    //     Debug.Log("--- RotateToTarget");
    //      StartCoroutine(  Rotate_func( target ) );
    //     // gameObject.transform.LookAt(target);
    // }

    
    // public void StopCoroutines(){ 
    //     Debug.Log("=== StopCoroutines");
    //     StopAllCoroutines();
    //     IsMoving = false;
    //     // StopCoroutine( "PathGo" );
    //     // StopCoroutine( "Rotate_func" );
    //     // StopCoroutine( "Move_func" );
    // }


    
    // public IEnumerator PathGo(){
    //     IsMoving = true;
    //     // Debug.Log(" Path.Position: "+  Path[0].position);
        
    //     if ( Path.Length != 0 && IsMoving)
    //     {
    //         for (int i = 0; i < Path.Length; i++)
    //         {
    //             // Vector3 Path_V = new Vector3( Path[i].position.x , Path[i].position.y ,  Path[i].position.z );
                
    //             Debug.Log(" Path.Position: "+  Path[i]);

    //             if (IsMoving)
    //             { 
    //                 yield return  Rotate_func( Path[i] ) ;
    //             }
    //             PathCount++;
    //         }
    //         if (IsloopPath && IsMoving)
    //         {
    //             PathCount = 0;
    //             StartCoroutine( PathGo() ); 
    //         }
    //     }
    // }

    // private IEnumerator Rotate_func(Transform byAngles )
    // {
    //     for (var t = 0f; t < 1; t += Time.deltaTime / RotateSpeed)
    //     {
    //         Vector3 lTargetDir = byAngles.position - transform.position;
    //         lTargetDir.y = 0.0f;
    //         transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), t * RotateSpeed);
    //         // yield return null;
    //         yield return new WaitForFixedUpdate();
    //     }
    //     Debug.Log(" is Rotae Finsh"); 
    //     // yield return null;
    //     Vector3 path_V3 = new Vector3(byAngles.position.x , byAngles.position.y ,  byAngles.position.z );
    //     // Debug.Log(" path_V3:" + path_V3); 
    //     if (IsMoving)
    //     { 
    //         yield return Move_func(path_V3 , MoveSpeed );
    //     }
    // }
    // private IEnumerator Move_func(  Vector3 target , float Speed , float MovingTime = 100f){
        
    //     target.y = thisObj_V3.y;
    //     /// /////
    //     // var cc = GetComponent<CharacterController>();
    //     for (var t = 0f; t < 1; t += Time.deltaTime / MovingTime)      //for (var t = 0f; t < 1; t += Time.deltaTime)
    //     {
    //         var offset = target - transform.position;
    //         //Get the difference.
    //         if(offset.magnitude > .1f) {    // .1f
    //             offset = offset.normalized * Speed;
    //             // offset = offset.normalized;
    //             characterController.Move(offset * Time.deltaTime);
    //         }else{
    //             Debug.Log(" break ");
    //             yield break;
    //         } 
    //             // Debug.Log(" yield return null; ");
    //         yield return null;
    //     }
    // }

    // ////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // map



    /*
    private void MoveCharacter(int Move_status , Vector3 MovePos){
        switch (Move_status)
        {
        case 2:
            Debug.Log(""); 
            Debug.Log("Rotate , back 180");
            StartCoroutine(Rotate_func(Vector3.down * 180, RotateSpeed) ); //down: Vector3(0, -1, 0).
            break;
        case 1:
            Debug.Log("stop");
            IsMoving = false;
            break;
        case 0:
            Debug.Log("move forward");
            StartCoroutine( Move_func( MovePos , MoveSpeed) );
            break;
        default:
            // Debug.Log("move forward");
            // StartCoroutine( Move_func( MovePos , MoveSpeed) );
            break;
        }
    }

    public void Base_Behaviour(  ){
        int behaviour_num = Random.Range(0 , 2);
        Vector3 targetPosition = new Vector3();

        targetPosition = RandomMovement();
        MoveCharacter(0 , targetPosition);  // (behaviour_num, targetPosition)
    }
    // public Vector3 trytry(){
    //     Vector3 targetPosition = new Vector3();
    //     targetPosition = RandomMovement();
    // }

    public Vector3 RandomMovement ( ){
        Vector3 targetPosition = new Vector3();
        targetPosition = pos;

        var _moveMaxRange = moveMaxRange/2;
        Debug.Log( "=" +_moveMaxRange);
        var RandomRange_X = Random.Range( -_moveMaxRange, _moveMaxRange); // /2 Because Range doble  
        var RandomRange_Z = Random.Range( -_moveMaxRange, _moveMaxRange);
        
        targetPosition.x += RandomRange_X;
        targetPosition.z += RandomRange_Z;

        Debug.Log("=== " + pos + " || "+ targetPosition );

        while ( !(Vector3.Distance(pos, targetPosition) < moveMaxRange) )  
        {
            Debug.Log(" out of range ");
            var RX = Random.Range( -_moveMaxRange, _moveMaxRange); // /2 Because Range doble  
            var RZ = Random.Range( -_moveMaxRange, _moveMaxRange);
            targetPosition.x += RX;
            targetPosition.z += RZ;
        }
        
        return targetPosition;
    }
        // /////////////////////

    // public void RandomMovement ( ){
        // Vector3 targetPosition = new Vector3();
        // targetPosition = pos;

        // var _moveMaxRange = moveMaxRange/2;
        // Debug.Log( "=" +_moveMaxRange);
        // var RandomRange_X = Random.Range( -_moveMaxRange, _moveMaxRange); // /2 Because Range doble  
        // var RandomRange_Z = Random.Range( -_moveMaxRange, _moveMaxRange);
        
        // targetPosition.x += RandomRange_X;
        // targetPosition.z += RandomRange_Z;

        // Debug.Log("=== " + pos + " || "+ targetPosition );
        // //         while ( !(Vector3.Distance(pos, targetPosition) < moveMaxRange) )
        // //         {
        // //             Debug.Log(" in range ");
        // //         }
        // // Debug.Log(" out of range ");

        // while ()
        // {
            
        // }

        // // Ranodom 
        // if(Vector3.Distance(pos, targetPosition) < moveMaxRange){
        //     Debug.Log(" in range ");
        //     StartCoroutine( Move_func( targetPosition,  MoveSpeed ) );

        // }else{
        //     Debug.Log(" out of range ");
        //     Base_Behaviour( );
        // }
        // /// 
    // }

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

    protected IEnumerator Move_func(  Vector3 target , float Speed , float MovingTime = 100f){
        // Vector3 forward = transform.TransformDirection(Vector3.forward);
        // // characterController.Move(forward * Speed);
        
        //  for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        // {
        //     characterController.Move(forward * Speed);
        //     yield return null;
        // }

        /// /////
        // var cc = GetComponent<CharacterController>();
        for (var t = 0f; t < 1; t += Time.deltaTime / MovingTime)      //for (var t = 0f; t < 1; t += Time.deltaTime)
        {
            var offset = target - transform.position;
            //Get the difference.
            if(offset.magnitude > .1f) {    // .1f
                offset = offset.normalized * Speed;
                // offset = offset.normalized;
                characterController.Move(offset * Time.deltaTime);
            }else{
                Debug.Log(" break ");
                Base_Behaviour();
                yield break;
            } 
                // Debug.Log(" yield return null; ");
            yield return null;
        }
    }

        // thisObj.transform.Rotate( 0 , RotateRange *Time.deltaTime , 0 );
        // t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    protected IEnumerator Rotate_func(Vector3 byAngles, float inTime)
     {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
    }*/


    /*
     // debug only
                        if ( ( objectInfo.completeCount + objectInfo.failCount) != 0 &&  a  != (objectInfo.completeCount + objectInfo.failCount) )
                        {
                            a = ( objectInfo.completeCount + objectInfo.failCount);
                            // Debug.Log(" || CC: "+ ( objectInfo.completeCount) + " || FC: " + objectInfo.failCount +" ||TO: "+objectInfo.TotalObjectCount() );   //"=== PC: "+ progressCount + 
                       // Debug.Log(" || CC: "+ ( objectInfo.completeCount)  +"===TObjInt: "+objectInfo.objectLists[ (objectInfo.objectLists.Count)-1 ].isComplete  + " ||Count.: "+ objectInfo.objectLists.Count  );
                       
                        }
    */

