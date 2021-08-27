using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System; 

using Random = UnityEngine.Random;

public class BaseGun : MonoBehaviour
{
    /// /// Not Using
    public enum AmmoTpye { Blue, green, yellow, red }    
    public AmmoTpye AmmoColor;
    public enum TrailColor { blue,green,yellow,red}
    public TrailColor trailColor;

    ///  ///
    public GameObject[] Shooting_point;
    public GameObject Bullet;
    public GameObject FireFlash;
    public String Holder = "";      // put player / enemy   player Comtroller  using tag or string

    public enum WeaponTpye { Pistol, ShotGun }   
    public WeaponTpye weaponTpye;

    // public Text ShootingType; 
    private GameObject poolObject;
    [SerializeField] protected bool isKeepShooting = false;

    [Header("Weapon statistics")]
    
    [Range(0f, 1000f)]  public float WeaponDamage = 0f;
    [Range(0f, 10f)]    public float FireRate  = 0f;      // shoot cooldown
    [Range(0f, 1000f)]  public float BulletSpeed = 0f;
    [Range(0, 180.0f)]  public float BulletRange = 0f;  // Not shooting the midden //  if 5(Y Rotota) == <-(-5 angle) midden (5 angle) ->
    [Range(0f, 100f)]    public float BulletDestoryTime = 0f;
    private bool CanFire = true;
    private bool Reloading = false;
    public int TotalAmmo = 0;   // gun can have totalAmmo
    public int CurrentAmmo  = 0;
    public float ReloadWeapon_time = 0;  // float 0.2 = 3s  (60/ (xx * 100) )
    public bool isPickup = false;
    public bool BulletLimit = true;

    public int Ammo  = 100;   // 00/XXX

    [Header("UI")]
    [SerializeField] protected GameObject popupPrefab;
    public Image Crosshair;
    public Image WeaponImg;
    public Image WeaponImg_Disable;
    [Header("AudioClip")]
    [SerializeField] protected AudioClip reloadAudio;
    [SerializeField] protected AudioClip fireAudio;


    [Header("Abitily")]
    public bool canPassThrough = false;
    private AudioSource audioSource;
    // public bool isPlayGun = false;
    public bool CanFire_get
    {
        get => CanFire;
        set => CanFire = value;
    }
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private GunInfoPanel popupInfoPanel;
    
    public void shooting_func(){
        if(CanFire){
            if(CurrentAmmo > 0){
                Debug.Log("=== shootingBullet!!! ");
                // CurrentAmmo--; 
                // CurrentAmmo -= Shooting_point.Length;

                if(audioSource != null){
                    audioSource.clip =fireAudio;
                    audioSource.Play();
                }
                
                bool multShoot = false;
                if (Shooting_point.Length > 1){ //check multipleShoot
                    multShoot = true;
                }
                    // Debug.Log("==== multShoot:" + multShoot);
                for (int i = 0; i < Shooting_point.Length; i++){
                    CurrentAmmo --;
                    // Debug.Log("==== CurrentAmmo:" + CurrentAmmo);
                    shootingBullet(BulletSpeed , BulletRange, BulletDestoryTime ,CurrentAmmo, multShoot);
                }


                if (CurrentAmmo == 0)   // No Ammo Auto reload
                {
                    StartCoroutine( ReloadWeapon_func() );
                    audioSource.clip = reloadAudio;
                    audioSource.Play();
                }
            }
            else{
                Debug.Log("=== Weapon Reloading!!! ");
                // StartCoroutine( ReloadWeapon_func() );
                // audioSource.clip = reloadAudio;
                // audioSource.Play();

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

        if (isKeepShooting)
        {
            shooting_func();
        }
    }

    public IEnumerator ReloadWeapon_func(){ 
        if(Reloading){
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

            Reloading = true;
            //use pool system
            if (canCloneBullet > 0)
            {  
                for (int i = 0; i < canCloneBullet; i++)
                {
                    // PoolSystem.Instance.SpawnToPool(Bullet );
                    PoolSystem.Instance.SpawnToPool(Bullet , Holder , poolObject );
                //     var bullet = Instantiate(Bullet, Shooting_point[0].transform.position, Shooting_point[0].transform.rotation); //Bullet , transform.position = firePoint
                }
                if (ReloadWeapon_time != 0){
                    yield return new WaitForSeconds(60 / (ReloadWeapon_time  * 100));
                }else{
                    yield return new WaitForFixedUpdate();
                }
                Reloading = false;

                CurrentAmmo = canCloneBullet; 
                if (Ammo > TotalAmmo && BulletLimit){ 
                    Ammo -= TotalAmmo;
                }else{
                    Ammo = 0;
                }
            }

            if (isKeepShooting){
                // shooting_func();
            }
           
        
        }
        
        // if (Ammo == 0){
        //     Debug.Log(" i need Ammo !!!");
        // }else{
        //     Ammo -= TotalAmmo;
        // }
        // CurrentAmmo = TotalAmmo;   

        /*
        Reloading = true;
            //use pool system
            for (int i = 0; i < TotalAmmo; i++)
            {
                PoolSystem.Instance.SpawnToPool(Bullet );
            //     var bullet = Instantiate(Bullet, Shooting_point[0].transform.position, Shooting_point[0].transform.rotation); //Bullet , transform.position = firePoint
            }
            yield return new WaitForSeconds(60 / (ReloadWeapon_time  * 60));
            Reloading = false;
            
            CurrentAmmo = TotalAmmo;  
        */
    }

    // Start is called before the first frame update
    protected void Start()
    {
        CurrentAmmo = TotalAmmo;   
    }

    public void pickupGun_cloneBullet(){

        ClosePopupGunInfo();
        //use pool system
        // PoolSystem.Instance.CreatePoolForBullet(Holder , this.name);
        poolObject = null;
        poolObject = PoolSystem.Instance.CreatePoolForBullet(Holder ,this.name);//this.name
        
        for (int i = 0; i < CurrentAmmo; i++)
        {
            PoolSystem.Instance.SpawnToPool(Bullet , Holder , poolObject );
        }
    }


    public void bulletAdd(){
        
        // for (int i = CurrentAmmo; i < CurrentAmmo; i++)
        // {
        //     PoolSystem.Instance.SpawnToPool(Bullet , Holder , poolObject );
        // }
    }

   
    public void shootingBullet(float bulletSpeed ,float  bulletRange, float BulletDestoryTime , int count , bool multipleShoot =false){
        // Shooting_point[count].GetComponent<Rigidbody>().AddForce(0, 0, 1);

        // Projectile bullet = Shooting_point[count].GetComponent<Projectile>();
        Projectile bullet = null;
        // bullet.bulletDamage = WeaponDamage;

        if ( Holder == "Player" ){    // isPlayer 
            // bullet.gameObject.tag = "PlayerBullet";
            bullet =  poolObject.transform.GetChild( count ).GetComponent<Projectile>();
            

        }else if( Holder == "Enemy" ){     // isEnemy
        // bullet.Bullet_rb.gameObject.tag = "EnemyBullet";
            bullet =  poolObject.transform.GetChild( count ).GetComponent<Projectile>();
            // bullet =  PoolSystem.Instance.enemyAcre.transform.GetChild( count ).GetComponent<Projectile>();
        }
        Color _c = trailColor_map();
        StartCoroutine( FireFlash_func() );
        
        if (multipleShoot)
        {
            bullet.Fire(  bulletSpeed ,  bulletRange,  BulletDestoryTime , Shooting_point[count].transform.position, Shooting_point[count].transform.rotation ,WeaponDamage, _c , canPassThrough); // weaponEnd.transform.position, weaponEnd.transform.rotation
        }else{
            bullet.Fire(  bulletSpeed ,  bulletRange,  BulletDestoryTime , Shooting_point[0].transform.position, Shooting_point[0].transform.rotation ,WeaponDamage, _c , canPassThrough); // weaponEnd.transform.position, weaponEnd.transform.rotation
        }
        // for (int i = 0; i < Shooting_point.Length; i++)
        // {
        //     Debug.Log("==== Shooting_point.Length:" + Shooting_point[i].name);
            // }
        // bullet.Fire(  bulletSpeed ,  bulletRange,  BulletDestoryTime , Shooting_point[0].transform.position, Shooting_point[0].transform.rotation ,WeaponDamage, _c , canPassThrough); // weaponEnd.transform.position, weaponEnd.transform.rotation
        
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

    public IEnumerator FireFlash_func( float timer = 0.1f){
        if(FireFlash == null) yield break;
        FireFlash.SetActive(true);
        yield return new WaitForSeconds(timer);
        FireFlash.SetActive(false);
    }
    
    // private void OnTriggerExit(Collider other){
        // if(other.gameObject.tag == "Player"){
        //     popupInfoPanel.DestroyTimer();
        // } 
    // }

    public void ClosePopupGunInfo(){
        if (popupInfoPanel !=null)
        {
            popupInfoPanel.DestroyTimer();
        }
    }

    private Color trailColor_map(){
        Color i = trailColor == TrailColor.blue   ? Color.blue :
                trailColor == TrailColor.green  ? Color.green :
                trailColor == TrailColor.yellow ? Color.yellow :
                trailColor == TrailColor.red    ? Color.red : Color.blue;
        return i;
    }

    
    public void PopupGunInfo(){
        Debug.Log(" is PopUp GunInfo" + gameObject);
        GameObject dialogLayer = GameObject.Find("DialogLayer");

        // GameObject instance = Instantiate(popupPrefab , transform.position , Quaternion.identity, transform);
        GameObject popupInfo_Clone = Instantiate(popupPrefab ,dialogLayer.transform );
        GunInfoPanel gunInfoPanel = popupInfo_Clone.GetComponent<GunInfoPanel>();

        popupInfoPanel = gunInfoPanel;

        gunInfoPanel.updateInfoText( weaponTpye.ToString() , WeaponDamage.ToString() );


        // GameObject popupClone = Instantiate(popupPrefab);
        // Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(gameObject.transform.position.x , gameObject.transform.position.y) );

        // popupClone.transform.SetParent(canvas.transform);
        // popupClone.transform.position = screenPosition;

        // Vector2 screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        // instance.transform.SetParent(dialogLayer.transform, false);
        // instance.transform.position = screenPosition;
        // instance.SetText(text);
    }

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
