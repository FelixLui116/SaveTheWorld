using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Text;
public class UIContrller : MonoBehaviour
{
    [Header("== Player ==")]
    
    public PlayerCharacterController playerCharacterController;
    // public Text HP , Bullet;
    public Button[] skillBtn;
    public ShootingButton ShootBtn; // base shooting
    public Button dodgeBtn; // base shooting
    private void Awake() {
        // if (ShootBtn != null){
        if (dodgeBtn != null)   dodgeBtn.onClick.AddListener(() => playerCharacterController.dodge_click(dodgeBtn) );
        
    }
    void Start()
    {
        // Hp_Text();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCharacterController.baseGun != null && playerCharacterController != null)
        {
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
