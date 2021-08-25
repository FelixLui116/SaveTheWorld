using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_rotate_object : MonoBehaviour
{
    public GameObject player;
    public VariableJoystick variableJoystick;
    public float rotatespeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FixedUpdate()
    {
        // if (true)
        // {
            
        // }
        // Vector3 direction = new Vector3(variableJoystick.Horizontal , 0,   variableJoystick.Vertical ).normalized;
        
        Quaternion TargetRotation;
         /// /// rotate
        float Angle;
        Angle = Mathf.Atan2 (variableJoystick.Horizontal, variableJoystick.Vertical);
        Angle = Mathf.Rad2Deg * Angle;
        // Angle += MainCamera.eulerAngles.y;

        TargetRotation = Quaternion.Euler(0, Angle, 0);
        // Debug.Log("TargetRotation: " + TargetRotation);
        if( !(TargetRotation.x == 0 &&TargetRotation.y == 0 &&TargetRotation.z ==0) ){
             transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, rotatespeed * Time.deltaTime);
       
        }
        /// rotate end 



        // var xMove = variableJoystick.Horizontal;
        // var zMove = variableJoystick.Vertical;
        // if (xMove > 0)
        //     player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(Vector3.right), 2f * Time.deltaTime);
        // else if (xMove < 0)
        //     player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(Vector3.left), 2f * Time.deltaTime);
        // if (zMove > 0)
        //     player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(Vector3.forward), 2f * Time.deltaTime);
        // else if (zMove < 0)
        //     player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(Vector3.back), 2f * Time.deltaTime);
    }
}
