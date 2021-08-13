using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyState
{
    Idle, Rotate, Moving, GetTarget, Shooting
}
public class EnemyCharacterController : BaseCharacter
{
    //  transform.LookAt(target);

    // [SerializeField] protected float moveMaxRange = 50f;
    // private Vector3 pos;
    // [SerializeField] private float MoveSpeed = 1f;      // in time // 一定時間內完成
    // [SerializeField] private float RotateSpeed = 5f;    // in time // Roatate in X sec  一定時間內完成

    // [SerializeField] private float Forward = 10f;
    // protected bool IsMoving = false;

    protected bool IsGettarget = false;
    public Transform targetPlayer;
    [SerializeField] protected EnemyCollider enemyCollider;
    [SerializeField] protected  float DetectRange = 10f;
    [SerializeField] private MovePath movePath;
    
    private bool detected_Target = false;
    private EnemyState _currentState = EnemyState.Idle;
    protected EnemyState CurrentState
    {
        // get => _currentState;
        // set
        // {
        //     if (_currentState == value) return;
        //     EnemyStateChangedEvent(_currentState);
        // }
        get { return _currentState; }
        set
        {
            _currentState = value;
            EnemyStateChangedEvent(_currentState);
        }
    }

    void Start()
    { 
        // StartCoroutine( movePath.PathGo() ); 
        CurrentState = EnemyState.Idle;  
        
        enemyCollider.ApplyChangeHPAction = GetHit;

        baseGun.pickupGun_cloneBullet();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))      // Test Function
        {
            CurrentState = EnemyState.Rotate;
        }if (Input.GetKeyDown(KeyCode.W))      // Test Function
        {
            CurrentState = EnemyState.Shooting;
        }if (Input.GetKeyDown(KeyCode.E))      // Test Function
        {
            CurrentState = EnemyState.Moving;
        }
    }


    private void EnemyStateChangedEvent(EnemyState state){
        Debug.Log(" Enemy state: " + state);
        switch (state)
        {
            case EnemyState.Moving:
                break;
            case EnemyState.Rotate:
                break;
            case EnemyState.GetTarget:
                movePath.StopCoroutines();
                break;
            case EnemyState.Shooting:

                baseGun.shooting_func();
                break;
            case EnemyState.Idle:
                StartCoroutine( movePath.PathGo() ); 
                
                CurrentState = EnemyState.Moving;  

                break;
            default:
                break;
        }
    }
    
    private void FixedUpdate() {
        if (targetPlayer != null && !detected_Target)
        {
            DetectTarget();
        }

        if (Input.GetKeyDown("space"))      // Test Function
        {
            baseGun.shooting_func();
        }
    }

    private void DetectTarget(){
        Vector3 targetPlayer_V3  = new Vector3(targetPlayer.position.x ,targetPlayer.position.y , targetPlayer.position.z );
        Vector3 thisObj_V3 = new Vector3( transform.position.x ,transform.position.y , transform.position.z);

        if(Vector3.Distance(thisObj_V3, targetPlayer_V3) < DetectRange)
        {
            //Do something
            // Debug.Log(" DetectTarget: " + targetPlayer.gameObject.name);
            detected_Target = true;
            
            CurrentState = EnemyState.GetTarget;   // movePath.StopCoroutines();
            // movePath.Base_moveToTarget( targetPlayer );

        }else{
            detected_Target = false;
            // CurrentState = EnemyState.Idle;
        }
    } 

    protected override void GetHit(){
        HitAudio.Play();
    }
}
