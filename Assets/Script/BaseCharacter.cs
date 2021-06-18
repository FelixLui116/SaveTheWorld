using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected int current_health;
    [SerializeField] protected int health_max;
    [SerializeField] protected string _name;
    protected GameObject coin_Obj;
    protected int _coin;
    protected GameObject [] weapon;

    public BaseGun baseGun;
    public GameObject holdGunPos;

    private bool pressing_Shoot = false;

    public CharacterController characterController;
    [SerializeField] protected Transform putGunPos;
    // public LevelController levelController;  
    
    private void Awake() {
        // levelController = GameObject.Find("levelController").GetComponent<LevelController>();
    }

    void Start()
    {
        // if(Gun.Length > 0){
            // BaseGun baseGun = Gun[0].GetComponent<BaseGun>();
        // }
        GetWeapon_onHold();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
       PressShoot();
        //  if (Input.GetKeyDown("space"))      // Test Function
        // {
        //     // print("space key was pressed");
           
        // } 
  
    }

    private void PressShoot(){
        if (Input.GetKeyDown("space"))      // Test Function
        {
            pressing_Shoot = true;
        }
        else if (Input.GetKeyUp("space"))      // Test Function
        {
            pressing_Shoot = false;
        }
        if(pressing_Shoot){
            print("space key was pressed");
            if(baseGun != null ){ 
                if (baseGun.CanFire_get)
                {
                    baseGun.shooting_func();
                }
            }
        }
    }

    // can be  oneFunction 
    // public void changeWeapon_func(int num){ 
    //     for(int i = 0; i < weapons.Lenght ; i++) { // weapons.Length
    //         if(i == num)
    //             weapons[i].gameObject.SetActive(true);
    //             //Base Gun =   weapons[i].gameObject.GetCompount<baseGun>();
    //         else
    //             weapons[i].gameObject.SetActive(false);
    //     }
    // } 
    // public void switchGun_Func(){
    //     baseGun.gameObject.transform.SetParent(putGunPos);
    //     baseGun = null;
    // } 

    public void GetWeapon_onHold(){
        if(holdGunPos == null) return;
        if(holdGunPos.transform.childCount == 0){ 
            return;
        }else{
            baseGun = holdGunPos.transform.GetChild(0).GetComponent<BaseGun>();}
    }
    
    
    // pick Gun is working
    // public void  OnControllerColliderHit(ControllerColliderHit hit){
    //     if (hit.gameObject.tag == "Weapon"){
    //         // // BaseGun -> isPick = trun (default: false)
    //         // // maybe stop some anim floating
    //         GameObject weapon = hit.gameObject;
    //         bool pickup_bool = weapon.GetComponent<BaseGun>().isPickup;
    //         if( !pickup_bool ){
    //             pickup_bool = true;
    //             weapon.transform.SetParent( holdGunPos.transform );  // holdGun.transform 
    //             weapon.transform.localPosition = Vector3.zero;  // reset position
    //             weapon.transform.localEulerAngles = Vector3.zero;               // reset rotation
                
    //             weapon.GetComponent<BaseGun>().Holder = "Player";
    //             GetWeapon_onHold();
    //             // weapon.Add(other.gameObject);   // add weapon

    //             // changeWeapon_func( weapons.Lenght );
    //         }
    //     }
    // }
    public void WeaponGet(GameObject obj){
        GameObject weapon = obj;
            bool pickup_bool = weapon.GetComponent<BaseGun>().isPickup;
            if( !pickup_bool ){
                pickup_bool = true;
                weapon.transform.SetParent( holdGunPos.transform );  // holdGun.transform 
                weapon.transform.localPosition = Vector3.zero;  // reset position
                weapon.transform.localEulerAngles = Vector3.zero;               // reset rotation
                
                weapon.GetComponent<BaseGun>().Holder = "Player";
                GetWeapon_onHold();
                // weapon.Add(other.gameObject);   // add weapon

                // changeWeapon_func( weapons.Lenght );
            }
    }

}
