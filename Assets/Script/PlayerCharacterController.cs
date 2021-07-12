using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class PlayerCharacterController : BaseCharacter
{

    // [Header("Skill")]
    private SkillController skill;
    
    // public Button ShootBtn;
    // public Button[] skillBtn;


    void Start()
    {
        
    }

    public void switchingWeapon_func(){
        if(HoldWeaponCount == 0) return;    // no gun

        Debug.Log( HoldWeaponCount + " || " + currentWeapon );
        // if (HoldWeaponCount != currentWeapon){
            
        // }
    }


    
    protected override void GetWeapon_onHold()
    {
        if(holdGunPos == null) return;
        if(holdGunPos.transform.childCount == 0) return;

        baseGun = holdGunPos.transform.GetChild(currentWeapon).GetComponent<BaseGun>();
    
        // baseGun = holdGunPos.transform.GetChild(0).GetComponent<BaseGun>();

        /*
        if(holdGunPos.transform.childCount == 0){ 
            return;
        }
        else if(holdGunPos.transform.childCount == 1){     // have gun in hand get more Gun!!
            
            baseGun = holdGunPos.transform.GetChild().GetComponent<BaseGun>();
        }
        else{
            baseGun = holdGunPos.transform.GetChild(0).GetComponent<BaseGun>();
        }
        */
    }
    
    

    // Update is called once per frame
    void Update()
    {
        // PressShoot();
        // if (Input.GetKeyDown("space"))      // Test Function
        // {
        //     print("space key was pressed");
        //     if(baseGun != null ){
        //         baseGun.shooting_func();
        //     }
        // }
    }

    
}
