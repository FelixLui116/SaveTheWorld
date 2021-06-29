using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField]protected  float DetectRange = 10f;
    [SerializeField] private MovePath movePath;

    void Start()
    {

    }

    void Update()
    {
        
    }
    
    private void FixedUpdate() {
        if (targetPlayer != null)
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
            Debug.Log(" DetectTarget: " + targetPlayer.gameObject.name);
        }
    } 
}
