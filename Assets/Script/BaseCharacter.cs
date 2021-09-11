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
    [SerializeField] protected int _coin = 0;
    public List<GameObject> weaponList = new List<GameObject>();

    public BaseGun baseGun;
    public GameObject holdGunPos;
    public GameObject SecGunPositon;

    private bool pressing_Shoot = false;
    
    protected int HoldWeaponCount = 0 , MaxHoldWeapon = 2;
    protected int currentWeapon = 0;

    public CharacterController characterController;
    // [SerializeField] protected Transform putGunPos;
    [SerializeField] protected float DestroyOjbectTimer = 0.0f;
    // public LevelController levelController;  
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip HitAudio;
    // [SerializeField] protected AudioClip HitAudioClip;
    public Transform effectPos;
    [SerializeField] protected GameObject floatingText;

    [Header("LockTraget")]
    [SerializeField] protected  float DetectRange = 10f;
    protected Transform targetPlayer;
    
    protected bool detected_Target = false;

    public int Current_health
    {
        get => current_health;
        set 
        { 
            current_health = value;
            CheckHp();
        }
    }
    public int Health_max
    {
        get => health_max;
        set { health_max = value; }
    }
    public int Coin
    {
        get => _coin;
        set { _coin = value; }
    }
    public bool Pressing_Shoot
    {
        get => pressing_Shoot;
        set { pressing_Shoot = value; }
    }
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
    //    PressShoot();
        //  if (Input.GetKeyDown("space"))      // Test Function
        // {
        //     // print("space key was pressed");
           
        // } 
  
    }

    public void PressShoot(){
        // if (Input.GetKeyDown("space"))      // Test Function
        // {
        //     pressing_Shoot = true;
        // }
        // else if (Input.GetKeyUp("space"))      // Test Function
        // {
        //     pressing_Shoot = false;
        // }

        if(pressing_Shoot){
            // print("space key was pressed");
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
    protected virtual void CheckHp(){
        // if (Current_health == 0)
        // {
        //     Debug.Log(" enemy is die need to destory !!!");
        //     DestroyOjbect(DestroyOjbectTimer);
        // }
    }


    protected virtual void GetHit(){
        // Debug.Log("");

        audioSource.clip = HitAudio;
        audioSource.Play();
    }
    protected virtual void GetWeapon_onHold(){
        // Debug.Log(" GetWeapon_onHold" +currentWeapon + " || HoldWeaponCount: "+HoldWeaponCount);  
        // Debug.Log(" GetWeapon_onHold" +holdGunPos + " || HoldWeaponCount: "+holdGunPos.transform.childCount);   

        if(holdGunPos == null) return;
        if(holdGunPos.transform.childCount == 0) return;

        // baseGun = holdGunPos.transform.GetChild(0).GetComponent<BaseGun>();
        // baseGun = weaponList[currentWeapon].GetComponent<BaseGun>();
    }

    public virtual void WeaponGet(GameObject obj){
        GameObject weapon = obj;
        // bool pickup_bool = weapon.GetComponent<BaseGun>().isPickup;
        BaseGun baseGun = weapon.GetComponent<BaseGun>();
        // bool pickup_bool = baseGun.isPickup;

        // baseGun.PopupGunInfo();
        // if( !pickup_bool ){
            Debug.Log(" is Full weapon : currentWeapon " +currentWeapon + " || HoldWeaponCount: "+HoldWeaponCount);
            


            baseGun.pickupGun_cloneBullet();
            if (HoldWeaponCount < MaxHoldWeapon)    // can Holding Gun total number
            {
                HoldWeaponCount ++;
                // pickup_bool = true;
                weaponList.Add(obj);

                // weapon.transform.SetParent( holdGunPos.transform );  // holdGun.transform 
                if (HoldWeaponCount > 1){
                    // weapon.transform.SetParent( SecGunPositon.transform );  // holdGun.transform 
                    ResetGunPosition(weapon ,  SecGunPositon.transform );
                }else{
                    ResetGunPosition(weapon ,  holdGunPos.transform );
                }

                weapon.GetComponent<BaseGun>().Holder = "Player";
                GetWeapon_onHold();
                // weapon.Add(other.gameObject);   // add weapon
            }
            else{       // really have two gun
                
                // Debug.Log(" is Full weapon : currentWeapon " +currentWeapon + " || HoldWeaponCount: "+HoldWeaponCount);
                WeaponDrop(currentWeapon , obj , baseGun);
            }
            // changeWeapon_func( weapons.Lenght );
        // }
    }
    protected void WeaponDrop(int weaponNum ,GameObject obj , BaseGun _baseGun ){
        // drop hand Gun 
        ResetGunPosition(weaponList[weaponNum] , LevelController.Instance.SceneBuilding.transform , gameObject.transform );
           
        // HoldWeaponCount--;
        Debug.Log(" is Full weapon : currentWeapon " +currentWeapon + " || HoldWeaponCount: "+HoldWeaponCount);
        
        // _baseGun.isPickup =false;

        weaponList[currentWeapon] = obj;

        GetWeapon_onHold(); 
        ResetGunPosition( obj , holdGunPos.transform ); // pickup Gun
        
        baseGun = _baseGun;
        PoolSystem.Instance.KillBulletPool(currentWeapon );
        Debug.Log("  weaponList.Count " + weaponList.Count );
        
        // weaponNum
    }

    protected void ResetGunPosition(GameObject weapon , Transform parent , Transform _position = null ){
        // Debug.Log("position: "+ position);
        weapon.transform.SetParent( parent.transform );  // holdGun.transform 
        if (_position != null)
        {
            // Drop Gun
            weapon.transform.localPosition = new Vector3( _position.position.x, (_position.position.y)+ 0.78f,  _position.position.z ) ;
        }else{
            weapon.transform.localPosition = Vector3.zero;  // reset position
        }
        weapon.transform.localEulerAngles = Vector3.zero;               // reset rotation
    }

    protected void DestroyOjbect (float timer = 0.0f) {
        Destroy(this.gameObject);  
    }

    public void CreateFolatingText(string _string = ""){
        var canvas = GameObject.Find("Canvas");
        GameObject floatingTextClone = Instantiate(floatingText, transform.position , Quaternion.identity, canvas.transform); //  PoolSystem.Instance.DestroyAcre.transform 
        
        floatingTextClone.transform.position = transform.position;
        // floatingTextClone.transform.position =  new Vector2 (transform.position.x + Random.Range(-0.5f, 0.5f) , transform.position.y  );
        floatingTextClone.GetComponent<FloatingText>().SetText(_string);
    }

}
