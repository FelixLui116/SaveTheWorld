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
    [SerializeField] protected EnemyCollider enemyCollider;
    [SerializeField] private MovePath movePath;
    [SerializeField] protected GameObject coinPrefab;

    [SerializeField] private GameObject lockimage;
    
    // private bool detected_Target = false;
    // [SerializeField] protected  float DetectRange = 10f;
    // protected Transform target_object;
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

        if(LevelController.Instance != null) target_object = LevelController.Instance.playerObject.transform;
    
        movePath.ApplyShoot = ChangeStateToShoot;
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Q))      // Test Function
        // {
        //     CurrentState = EnemyState.Rotate;
        // }if (Input.GetKeyDown(KeyCode.W))      // Test Function
        // {
        //     CurrentState = EnemyState.Shooting;
        // }if (Input.GetKeyDown(KeyCode.E))      // Test Function
        // {
        //     CurrentState = EnemyState.Moving;
        // }
    }

    private void ChangeStateToShoot(){
        CurrentState = EnemyState.Shooting;
    }

    private void EnemyStateChangedEvent(EnemyState state){
        Debug.Log(" Enemy state: " + state);
        switch (state)
        {
            case EnemyState.Moving:
                movePath.ToMove();
                break;
            case EnemyState.Rotate:
                break;
            case EnemyState.GetTarget:
                Debug.Log("--- GetTarget:");
                // movePath.StopCoroutines();

                movePath.KillAllAction();
                movePath.ToRotateTarget(target_object);
                
                // CurrentState = EnemyState.Shooting;  // == ChangeStateToShoot()

                break;
            case EnemyState.Shooting:

                baseGun.shooting_func();
                detected_Target = false;

                
                DetectTarget();
                if (detected_Target == false)   // end of shooting check the target in the side
                {
                    CurrentState = EnemyState.Idle;  
                    baseGun.Cancel_GunEff();
                }else{

                }
                
                break;
            case EnemyState.Idle:
                // StartCoroutine( movePath.PathGo() ); 
                
                movePath.KillAllAction();
                
                // if (detected_Target == false && CurrentState != EnemyState.Shooting)
                // {
                    // Debug.Log("detected_Target = " + detected_Target + "|| CurrentState: " + CurrentState);
                    CurrentState = EnemyState.Moving;  
                // }
                break;
            default:
                break;
        }
    }
    
    private void FixedUpdate() {
        if (target_object != null && !detected_Target && (CurrentState == EnemyState.Moving))
        {
            DetectTarget();
        }

        if (Input.GetKeyDown("space"))      // Test Function
        {
            baseGun.shooting_func();
            // FloatingTextController.CreateFloatingText( "Hello" , transform);
        }
    }

    private void DetectTarget(){
        Vector3 target_object_V3  = new Vector3(target_object.position.x ,target_object.position.y , target_object.position.z );
        Vector3 thisObj_V3 = new Vector3( transform.position.x ,transform.position.y , transform.position.z);

        if(Vector3.Distance(thisObj_V3, target_object_V3) < DetectRange)
        {
            //Do something
            detected_Target = true;
            
            CurrentState = EnemyState.GetTarget;   // movePath.StopCoroutines();
            // movePath.Base_moveToTarget( target_object );

        }else{
            detected_Target = false;
            // CurrentState = EnemyState.Idle;
        }
    } 

    protected override void GetHit(){
        audioSource.clip =HitAudio;
        audioSource.Play();
    }

    protected void CreateCoin(){
        GameObject coinClone = Instantiate(coinPrefab);
        var y_pos = this.gameObject.transform.position.y;
        Debug.Log("~~~" + coinClone.transform.position.y  +" || "+ this.gameObject.transform.position.y );
        coinClone.transform.position = new Vector3(this.gameObject.transform.position.x,1,this.gameObject.transform.position.z);
        
        Coin coinScript = coinClone.GetComponent<Coin>();
        coinScript.CoinNum = _coin;

    }
    protected override void CheckHp(){
        if (Current_health <= 0)
        {
            CreateCoin();
            Debug.Log(" enemy is die need to destory !!!");
            DestroyOjbect(DestroyOjbectTimer);
        }
    }

    public void Lockimage_Active(bool _On){
        if (lockimage == null){ return; }
        Debug.Log("== in lockimage Active: " + _On);
        lockimage.SetActive(_On);
    }
}
