using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using System.Text;
public class UIContrller : MonoBehaviour
{
    [SerializeField] private GameObject dialogLayer;
    
    [Header("UI PlayerInfo")]
    public Text health_text;
    public Slider healthBarSlider;
    public Image healthBar;
    public Text coin_text;

    [Header("== Player ==")]
    
    public PlayerCharacterController playerCharacterController;
    private PlayerCollider playerCollider;
    // public Text HP , Bullet;

    public GameObject PlayAgainPrefabs;

    [Header("== Button ==")]
    [SerializeField] private SkillController playerSkills;
    public Button[] skillBtn;
    private ShootingButton shootingButton; // base shooting
    public Button ShootBtn;
    public Button dodgeBtn; // base shooting
    public Button SwitchGunBtn; // base shooting
    public Button LockTragetBtn; // base shooting
    public Button InteractionsBtn; // base shooting
    // public PoolSystem poolSystem;

    /// Action Btn 
    private UnityAction BtnGetGun;

    private void Awake() {
        if (ShootBtn != null){
            shootingButton = ShootBtn.gameObject.GetComponent<ShootingButton>();
        }
        if (dodgeBtn != null)   dodgeBtn.onClick.AddListener(() => playerCharacterController.dodge_click(dodgeBtn) );
        if (SwitchGunBtn != null)   SwitchGunBtn.onClick.AddListener(() => playerCharacterController.SwitchWeapon_click(SwitchGunBtn) );
        if (skillBtn[0] != null)   skillBtn[0].onClick.AddListener(() => playerSkills.Controll_skill_1(playerCharacterController.gameObject.transform) );
        if (LockTragetBtn != null)   LockTragetBtn.onClick.AddListener(() => playerCharacterController.SwitchWeapon_click(SwitchGunBtn) );
        

        BtnGetGun = new UnityAction(() =>{ 
            playerCharacterController.WeaponGet(playerCharacterController.SelectedGun);
            PlayerBtnGetGun_Remove();
        });
        
        // if (InteractionsBtn != null)   InteractionsBtn.onClick.AddListener(() =>  );
        // if (skillBtn[1] != null)   skillBtn[1].onClick.AddListener(() => null );
        // if (skillBtn[2] != null)   skillBtn[2].onClick.AddListener(() => null );
        
        playerCharacterController= GameObject.Find("Player").GetComponent<PlayerCharacterController>();
         
        playerCollider = playerCharacterController.playerCollider;
    }
    void Start()
    {
        playerCollider.ApplyChangeHPAction = PlayerHealth_text_update;
        playerCollider.ApplyChangeCoinAction = PlayerCoin_text_update;

        playerCharacterController.ApplyPlayerDie = PlayerDie_Panel;
        playerCharacterController.ApplyBtnGetGun = PlayerBtnListenerGetGun_Add;
        playerCharacterController.ApplyBtnRemoveGun = PlayerBtnGetGun_Remove;
        PlayerHealth_text_update();
        PlayerCoin_text_update();
        // Skill_Btn();
        // Hp_Text();
        // SkillController playerSkills = playerCharacterController.skill;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCharacterController.baseGun != null && playerCharacterController != null)
        {
            if (!playerCharacterController.CanSwitchWeapon) // is Changing Weapon not shoot
            {
                return;
            }
            // Bullet_Text();
            // playerCharacterController.PressShoot();
            if (shootingButton.PressDown_GET){    //PressDown

            // Debug.Log(" Is pressing ");
                playerCharacterController.Pressing_Shoot = true;
                playerCharacterController.PressShoot();
            }
            else{      // PressUP
                playerCharacterController.Pressing_Shoot = false;
            }
        }
    }
    private void PlayerHealth_text_update (){   // call back ApplyChangeHPAction
        int health_     =  playerCharacterController.Current_health;
        int health_max  =  playerCharacterController.Health_max ;
        
            // PlayerHealth_text_update( player.Current_health , player.Health_max  );
        // int a = 100;
        // int b = 50;
        // float c  =(float)(b/a);
        // Debug.Log("=== "+ c );

        
        // Debug.Log("=== " + health_  +"  " + health_max +"  " + ( health_/health_max ) );
        float _Hp = ((float)health_  / (float)health_max ); // 0.XXXX, 1=100% , 0.5=50%
        Color _hpColor = ( _Hp <= 0.3) ? Color.red : (_Hp <= 0.5) ? Color.yellow : (_Hp <= 0.8) ? Color.green : Color.green; 

        // Debug.Log("=== _Hp: " + _hpColor + " _Hp: " + _Hp );

        // health_text.color = _hpColor;
        health_text.text = health_.ToString() + " / "+ health_max.ToString();
        healthBar.color = _hpColor;
        healthBarSlider.value = _Hp;
        Debug.Log("=== _Hp: " + healthBarSlider.value );

    }

    private void PlayerCoin_text_update(){
        int _coin = playerCharacterController.Coin;

        coin_text.text = _coin.ToString();
        // Debug.Log("=== _coin: " + _coin);

    }

    private void PlayerDie_Panel(){
        GameObject panel_obj = Instantiate( PlayAgainPrefabs, dialogLayer.transform); // Clone in Canvas
    }

    private void PlayerBtnListenerGetGun_Add(){
        InteractionsBtn.onClick.AddListener(BtnGetGun);
        // InteractionsBtn.onClick.AddListener(() =>  playerCharacterController.WeaponGet(playerCharacterController.SelectedGun) );
    }
    private void PlayerBtnGetGun_Remove(){
        Debug.Log("removing WeaponGet from button"); 
        InteractionsBtn.onClick.RemoveListener(BtnGetGun);
        // InteractionsBtn.onClick.RemoveListener( );
    }

    // public void Skill_Btn(){
    //     // for (int i = 0; i < skillBtn.length; i++)
    //     // {
    //         // skillBtn[i].onClick.AddListener(() =>  );
    //     // }
    // }
    // private void FixedUpdate() {
    //     if (playerCharacterController.baseGun != null && playerCharacterController != null)
    //     {
    //         // Bullet_Text();
    //         // playerCharacterController.PressShoot();

    //         if (ShootBtn.PressDown_GET){    //PressDown

    //         Debug.Log(" Is pressing ");
    //             playerCharacterController.Pressing_Shoot = true;
    //             playerCharacterController.PressShoot();
    //         }
    //         else{      // PressUP
    //             playerCharacterController.Pressing_Shoot = false;
    //         }
    //     }
    // }

    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     Debug.Log(this.gameObject.name + " Was Clicked.");
    // }

    // public void Bullet_Text( ){
    //     var total_bullet = baseCharacter.baseGun.TotalAmmo.ToString();
    //     var current_Bullet = baseCharacter.baseGun.CurrentAmmo.ToString();
    //     var all_bullet = baseCharacter.baseGun.Ammo.ToString();

    //     Bullet.text =  current_Bullet+ " / " +total_bullet + "/n" +all_bullet;
    //     // txt = Ammo
    // }

    // public void Hp_Text( ){  
    //     // xx / xx
    //     HP.text = baseCharacter.Current_health.ToString() + " / " +baseCharacter.Health_max.ToString();
    // }
}
