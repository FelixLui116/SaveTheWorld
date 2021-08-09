using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{

    public GameObject[] enemyType;
    public PlayerCharacterController player; 

    [Header("UI")]
    public Text health_text;
    public Image[] Ammo_Color;
    public Text Debug_Text;
    public Image GunUI_Image = null;  // baseCharacter.baseGun. ( WeaponImg , WeaponImg_Disable)
    public Text AmmoText;

    
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth_text_update( player.Current_health , player.Health_max  );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  savePoint(){
        GlobalManager.Instance._PlayerData.money = 1111;

        GlobalManager.Instance.SaveIntoJson();
    }

    // // like this Ammo_text_update(1,28, 1000); 
    public void Ammo_text_update(int CurrentAmmo ,int TotalAmmo ,int Ammo){
    //     // something like this dispaly
    //     //  0/28
    //     //  200
            AmmoText.text = BulletText( CurrentAmmo, TotalAmmo , Ammo );
    }
    private string BulletText(int CurrentAmmo ,int TotalAmmo ,int Ammo) // CurrentAmmo/ TotalAmmo  (new line) Ammo
    {
        if (Ammo!= null){
            
        }else{
        
        }
        return  CurrentAmmo +"/"+ TotalAmmo + "\n" + Ammo;
    }

    private void PlayerHealth_text_update ( int health_ , int health_max){

        // int a = 100;
        // int b = 50;
        // float c  =(float)(b/a);
        // Debug.Log("=== "+ c );

        
        // Debug.Log("=== " + health_  +"  " + health_max +"  " + ( health_/health_max ) );
        float _Hp = ((float)health_  / (float)health_max ); // 0.XXXX, 1=100% , 0.5=50%
        Color _hpColor = ( _Hp <= 0.2) ? Color.red : (_Hp <= 0.5) ? Color.yellow : (_Hp <= 0.8) ? Color.green : Color.green; 

        Debug.Log("=== _Hp: " + _hpColor + " _Hp: " + _Hp );

        health_text.color = _hpColor;

        health_text.text = health_.ToString() + " / "+ health_max.ToString();
    }
    
}
