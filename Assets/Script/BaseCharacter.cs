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
    public void GetWeapon_onHold(){
        if(holdGunPos == null) return;
        if(holdGunPos.transform.childCount == 0){ 
            return;
        }else{
            baseGun = holdGunPos.transform.GetChild(0).GetComponent<BaseGun>();}
    }
    //

    
    // pick Gun
    // public void OnCollisionEnter(Collider other){ 
    //     if (other.gameObject.tag == "Weapon"){
    //         // // BaseGun -> isPick = trun (default: false)
    //         // // maybe stop some anim floating

    //         if(!baseGun.isPick){
    //             baseGun.isPick = true;
    //             other.gameObject.transform.SetParent( holdGunPos.transform );  // holdGun.transform 
    //             other.gameObject.transform.position = new Vector3(0,0,0);   // reset position
    //             other.gameObject.transform.Rotate(0, 0, 0);                 // reset rotation
                
    //             // weapon.Add(other.gameObject);   // add weapon

    //             // changeWeapon_func( weapons.Lenght );
    //         }
    //     }
    // }

}
