using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public CharacterController playerController ;
    public float gravity = -9.81f;
    public GameObject player_body;
    Quaternion TargetRotation;
    public float rotatespeed = 50.0f;
    public bool isEnabled
    {
        get => enabled;
        set 
        {
            enabled = value;

        Debug.Log("~~~ " + value);
            if (enabled)
            {
                this.enabled = true;
            }else{
                this.enabled = false;
            }
        }
    }
    private Touch initTouch = new Touch();

    private void Awake() {
         variableJoystick = GameObject.Find("Joystick_L").GetComponent<VariableJoystick>();
        // variableJoystick = Joystick_L_obj.GetComponent<VariableJoystick>() ;
    }
    public void FixedUpdate()
    {
        
        // float horizontal = Input.GetAxisRaw("Horizontal");
        // float vertical = Input.GetAxisRaw("Vertical");

        var gravity_ = gravity* Time.deltaTime;
        // // var gravity_ -= 9.81 * Time.deltaTime;
        // playerController.Move( new Vector3(0, gravity_, 0) );
        if ( playerController.isGrounded ){ 
            // Debug.Log("CharacterController is grounded");
            gravity_ = 0;
        };

        
        
        Vector3 direction = new Vector3(variableJoystick.Horizontal ,gravity_,   variableJoystick.Vertical ).normalized;
        if(direction.magnitude >= 0.1f){
            playerController.Move(direction * speed * Time.deltaTime);

        }

         /// /// rotate
        // Quaternion TargetRotation;
        float Angle;
        Angle = Mathf.Atan2 (variableJoystick.Horizontal, variableJoystick.Vertical);
        Angle = Mathf.Rad2Deg * Angle;
        // Angle += MainCamera.eulerAngles.y;

        TargetRotation = Quaternion.Euler(0, Angle, 0);
        // Debug.Log("TargetRotation: " + TargetRotation);
        if( !(TargetRotation.x == 0 &&TargetRotation.y == 0 &&TargetRotation.z ==0) ){
             transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, rotatespeed * Time.deltaTime);
       
        }

        /// /// rotate
        // float Angle;
        // Angle = Mathf.Atan2 (variableJoystick.Horizontal, variableJoystick.Vertical);
        // Angle = Mathf.Rad2Deg * Angle;
        // // Angle += MainCamera.eulerAngles.y;

        // TargetRotation = Quaternion.Euler(0, Angle, 0);
        // transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, 2.0f * Time.deltaTime);
        /// rotate end 

    }
}