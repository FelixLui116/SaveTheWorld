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
    
    // private bool detected_Target = false;
    // [SerializeField] protected  float DetectRange = 10f;
    // protected Transform targetPlayer;
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

        targetPlayer = LevelController.Instance.playerObject.transform;
    
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
                movePath.ToRotateTarget(targetPlayer);
                
                // CurrentState = EnemyState.Shooting;  // == ChangeStateToShoot()

                break;
            case EnemyState.Shooting:

                baseGun.shooting_func();
                detected_Target = false;

                CurrentState = EnemyState.Idle;
                // DetectTarget();
                
                break;
            case EnemyState.Idle:
                // StartCoroutine( movePath.PathGo() ); 
                
                movePath.KillAllAction();
                
                CurrentState = EnemyState.Moving;  

                break;
            default:
                break;
        }
    }
    
    private void FixedUpdate() {
        if (targetPlayer != null && !detected_Target && (CurrentState == EnemyState.Moving))
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
        Vector3 targetPlayer_V3  = new Vector3(targetPlayer.position.x ,targetPlayer.position.y , targetPlayer.position.z );
        Vector3 thisObj_V3 = new Vector3( transform.position.x ,transform.position.y , transform.position.z);

        if(Vector3.Distance(thisObj_V3, targetPlayer_V3) < DetectRange)
        {
            //Do something
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
}
