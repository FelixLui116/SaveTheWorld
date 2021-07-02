using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyState
{
    Idle, Rotate, Moving, Stop, Shooting
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
    [SerializeField] protected  float DetectRange = 10f;
    [SerializeField] private MovePath movePath;

    private bool detected_Target = false;
    private EnemyState _currentState = EnemyState.Idle;
    protected EnemyState CurrentState
    {
        get => _currentState;
        set
        {
            if (_currentState == value) return;
            EnemyStateChangedEvent(_currentState);
        }
    }

    void Start()
    {

        StartCoroutine( movePath.PathGo() ); 
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
        switch (state)
        {
            case EnemyState.Moving:
                Debug.Log(" in Change Moving");
                break;
            case EnemyState.Rotate:
                Debug.Log(" in Change rotate");
                break;
            case EnemyState.Stop:
                Debug.Log(" in Change stop");
                movePath.StopCoroutines();
                break;
            case EnemyState.Shooting:
                Debug.Log(" in Change shoot");
                break;
            case EnemyState.Idle:
                // Debug.Log(" in Change Idle");
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
    }

    private void DetectTarget(){
        Vector3 targetPlayer_V3  = new Vector3(targetPlayer.position.x ,targetPlayer.position.y , targetPlayer.position.z );
        Vector3 thisObj_V3 = new Vector3( transform.position.x ,transform.position.y , transform.position.z);

        if(Vector3.Distance(thisObj_V3, targetPlayer_V3) < DetectRange)
        {
            //Do something
            // Debug.Log(" DetectTarget: " + targetPlayer.gameObject.name);
            detected_Target = true;
            
            CurrentState = EnemyState.Stop;   // movePath.StopCoroutines();
            movePath.Base_moveToTarget( targetPlayer );

        }else{
            detected_Target = false;
        }
    } 
}
