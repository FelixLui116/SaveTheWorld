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
     [SerializeField] private MovePath movePath;

    void Start()
    {
    }

    void Update()
    {
        
    }


}
