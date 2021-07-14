using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class PlayerCharacterController : BaseCharacter
{

    // [Header("Skill")]
    private SkillController skill;

    private int lastWeapon;

    private float dodge_timer = 2.5f;
    private bool canDodging = true;
    // [SerializeField] protected GameObject playerBody;
    
    // public Button ShootBtn;
    // public Button[] skillBtn;


    void Start()
    {
        
    }

    public void switchingWeapon_func(){
        if(HoldWeaponCount == 0) return;    // no gun

        lastWeapon = currentWeapon;

        if (lastWeapon == 0)
        {
            currentWeapon = 1;
        }else{
            currentWeapon = 0;
        }

        // Debug.Log( HoldWeaponCount + " || " + currentWeapon );

        if ( weaponList.Count > 1)  //   need to have one weapon first
        {
            SelectWeapon(currentWeapon);
        }
        
    }

    protected void SelectWeapon(int current_Weapon ){
        Transform weaponPos , SecweaponPos;
        
        weaponPos = holdGunPos.transform ;
        SecweaponPos = SecGunPositon.transform ;

        ResetGunPosition(weaponList[current_Weapon] , weaponPos );
        ResetGunPosition(weaponList[lastWeapon] , SecweaponPos );
        
        GetWeapon_onHold(); // switch Base Gun Sprite in base character

    }
    
    protected override void GetWeapon_onHold()
    {
        if(holdGunPos == null) return;
        if(holdGunPos.transform.childCount == 0) return;

        baseGun = holdGunPos.transform.GetChild(0).GetComponent<BaseGun>();
    
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

    public void dodge_click (Button btn ){
        
        StartCoroutine( dodge_func(btn) );
    }
    private IEnumerator dodge_func ( Button btn ){
        Debug.Log("=== canDodging: " + canDodging);
        if (canDodging)
        {  
            canDodging = false;
            // canDodging = true;
            yield return Button_Loading(btn ,dodge_timer );
            canDodging = true;
        }
    
    }

    private IEnumerator Button_Loading(Button btn , float countTimer ){
        // btn..transform.GetChild(0).GetComponent<Image>();
        var LoadingBar = btn.transform.GetChild(0).GetComponent<Image>();
        float Timer = 1;
        LoadingBar.fillAmount = 1;
        // while (Timer > 0)
        while (LoadingBar.fillAmount > 0)
        {
            float deltaTime = Time.fixedDeltaTime / countTimer;
            LoadingBar.fillAmount -= deltaTime;
            if (LoadingBar.fillAmount < 0){
                LoadingBar.fillAmount = 0;
                yield break;            
            }
            Timer -= deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        // PressShoot();

        if (Input.GetKeyDown("space"))      // Test Function
        {
            switchingWeapon_func();
        }
    }

    
}
