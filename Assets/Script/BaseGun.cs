using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System; 

using Random = UnityEngine.Random;

public class BaseGun : MonoBehaviour
{
    public enum AmmoTpye { Blue, green, yollow, red }    
    public GameObject[] Shooting_point;
    public GameObject Bullet;
    public GameObject FireFlash;
    public String Holder = "";      // put player / enemy   player Comtroller  using tag or string
    public AmmoTpye AmmoColor;
    public AudioSource GunSound;
    // public bool isPlayGun = false;

    // public Text ShootingType; 

    [Header("Weapon statistics")]
    
    [Range(0f, 1000f)]  public float WeaponDamage = 0f;
    [Range(0f, 10f)]    public float FireRate  = 0f;      // shoot cooldown
    [Range(0f, 1000f)]  public float BulletSpeed = 0f;
    [Range(0, 180.0f)]  public float BulletRange = 0f;  // Not shooting the midden //  if 5(Y Rotota) == <-(-5 angle) midden (5 angle) ->
    [Range(0f, 10f)]    public float BulletDestory = 0f;
    private bool CanFire = true;
    private bool Raloading = false;
    public int TotalAmmo = 0;   // gun can have totalAmmo
    public int CurrentAmmo  = 0;
    public float ReloadWeapon_time = 0;
    public bool isPickup = false;
    public bool BulletLimit = true;

    public int Ammo  = 100;   // 00/XXX

    [Header("UI")]
    public Image Crosshair;
    public Image WeaponImg;
    public Image WeaponImg_Disable;

    public bool CanFire_get
    {
        get => CanFire;
        set => CanFire = value;
    }

    
    public void shooting_func(){
        if(CanFire){
            if(CurrentAmmo > 0){
                Debug.Log("=== shootingBullet!!! ");
                CurrentAmmo--; 
                if(GunSound != null){
                    GunSound.Play();
                }
                shootingBullet(BulletSpeed , BulletRange, BulletDestory ,CurrentAmmo);
            }
            else{
                Debug.Log("=== Weapon Reloading!!! ");
                StartCoroutine( ReloadWeapon_func() );
            }
        }
        
        // cooldown
        CanFire = false;
        StartCoroutine(WaitForFire());
    }
    private IEnumerator WaitForFire()
    {
        yield return new WaitForSeconds(60 / (FireRate * 60));
        CanFire = true;
    }

    public IEnumerator ReloadWeapon_func(){ 
        if(Raloading){
            // do nothing , waiting reload end 
        }else{
            
            int canCloneBullet;
            if (BulletLimit){

                Debug.Log("Ammo: "+ Ammo + "TotalAmmo: "+ TotalAmmo);
                canCloneBullet = (Ammo - TotalAmmo);
                if (Ammo < TotalAmmo){
                    canCloneBullet = Ammo;
                }
            }else{
                canCloneBullet = TotalAmmo;
            }
            Debug.Log("canCloneBullet: "+ canCloneBullet);

            Raloading = true;
            //use pool system
            if (canCloneBullet > 0)
            {
                for (int i = 0; i < canCloneBullet; i++)
                {
                    PoolSystem.Instance.SpawnToPool(Bullet );
                //     var bullet = Instantiate(Bullet, Shooting_point[0].transform.position, Shooting_point[0].transform.rotation); //Bullet , transform.position = firePoint
                }
                yield return new WaitForSeconds(60 / (ReloadWeapon_time  * 60));
                Raloading = false;

                CurrentAmmo = canCloneBullet; 
                if (Ammo > TotalAmmo && BulletLimit){ 
                    Ammo -= TotalAmmo;
                }else{
                    Ammo = 0;
                }
            }
           
        
        }
        
        // if (Ammo == 0){
        //     Debug.Log(" i need Ammo !!!");
        // }else{
        //     Ammo -= TotalAmmo;
        // }
        // CurrentAmmo = TotalAmmo;   

        /*
        Raloading = true;
            //use pool system
            for (int i = 0; i < TotalAmmo; i++)
            {
                PoolSystem.Instance.SpawnToPool(Bullet );
            //     var bullet = Instantiate(Bullet, Shooting_point[0].transform.position, Shooting_point[0].transform.rotation); //Bullet , transform.position = firePoint
            }
            yield return new WaitForSeconds(60 / (ReloadWeapon_time  * 60));
            Raloading = false;
            
            CurrentAmmo = TotalAmmo;  
        */
    }

    // Start is called before the first frame update
    protected void Start()
    {
        CurrentAmmo = TotalAmmo;   

        //use pool system
        for (int i = 0; i < TotalAmmo; i++)
        {
               PoolSystem.Instance.SpawnToPool(Bullet );
        //     var bullet = Instantiate(Bullet, Shooting_point[0].transform.position, Shooting_point[0].transform.rotation); //Bullet , transform.position = firePoint
        }
    }

   
    public void shootingBullet(float bulletSpeed ,float  bulletRange, float bulletDestory , int count){
        // Shooting_point[count].GetComponent<Rigidbody>().AddForce(0, 0, 1);

        // Projectile bullet = Shooting_point[count].GetComponent<Projectile>();
        Projectile bullet = null;
        bullet.bulletDamage = WeaponDamage;
        if ( Holder == "Player" ){    // isPlayer 
            bullet.Bullet_rb.gameObject.tag = "PlayerBullet";
            bullet =  PoolSystem.Instance.playerAcre.transform.GetChild( count ).GetComponent<Projectile>();
            

        }else if( Holder == "Enemy" ){     // isEnemy
        bullet.Bullet_rb.gameObject.tag = "EnemyBullet";
            bullet =  PoolSystem.Instance.enemyAcre.transform.GetChild( count ).GetComponent<Projectile>();
        }

        bullet.Fire(  bulletSpeed ,  bulletRange,  bulletDestory , Shooting_point[0].transform.position, Shooting_point[0].transform.rotation ); // weaponEnd.transform.position, weaponEnd.transform.rotation
        // transform.forward * bulletSpeed;
    }

    // get Ammo
    public void AddAmmoTpye(AmmoTpye ammoColor , int _ammoNum ){
        foreach (AmmoTpye i in Enum.GetValues(typeof(AmmoTpye)))  
        {
            if (ammoColor == i){
                Debug.Log(" get Ammo: " + ammoColor);
                Ammo += _ammoNum;
            }
        }
    }

    // private void OnTriggerEnter(Collider other) {
    //     if (!isPickup && other.gameObject.tag == "Player")
    //     {

    //     }   
    // }

    public void Test_Func(){
        // float bulletRange = 5f;
        // float range = Random.Range( -(bulletRange), bulletRange);
        //     Debug.Log("-----Range : " + Math.Round(range , 2) );
        //     range = (float)Math.Round(range , 2);   // to 0.00 
        //     Debug.Log("-----Range 2 : " + Math.Round(range , 2) );
    } 
    
    // Update is called once per frame
    void Update()
    {
        
    }

}
