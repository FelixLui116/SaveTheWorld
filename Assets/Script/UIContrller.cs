using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Text;
public class UIContrller : MonoBehaviour
{
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

    [Header("Skill")]
    [SerializeField] private SkillController playerSkills;
    public Button[] skillBtn;
    public ShootingButton ShootBtn; // base shooting
    public Button dodgeBtn; // base shooting
    public Button SwitchGunBtn; // base shooting
    // public PoolSystem poolSystem;
    private void Awake() {
        // if (ShootBtn != null){
        if (dodgeBtn != null)   dodgeBtn.onClick.AddListener(() => playerCharacterController.dodge_click(dodgeBtn) );
        if (SwitchGunBtn != null)   SwitchGunBtn.onClick.AddListener(() => playerCharacterController.SwitchWeapon_click(SwitchGunBtn) );
        if (skillBtn[0] != null)   skillBtn[0].onClick.AddListener(() => playerSkills.Controll_skill_1(playerCharacterController.gameObject.transform) );
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
            if (ShootBtn.PressDown_GET){    //PressDown

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
        GameObject panel_obj = Instantiate( PlayAgainPrefabs, this.gameObject.transform.parent); // Clone in Canvas
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
