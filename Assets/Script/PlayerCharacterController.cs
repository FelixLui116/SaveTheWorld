using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using DG.Tweening;
using UnityEngine.Events;

public class PlayerCharacterController : BaseCharacter
{
    // [Header("Skill")]
    // [SerializeField] public SkillController skill;
    
    public UnityAction ApplyPlayerDie , ApplyBtnGetGun , ApplyBtnRemoveGun;
    private int lastWeapon;    
    public PlayerCollider  playerCollider;

    [SerializeField] private float SwitchWeapon_timer = 0.5f;
    [SerializeField] private JoystickPlayerExample joystickPlayerScript;
    
    [Header("dodge")]
    [SerializeField] private float dodge_timer = 2.5f;
    [SerializeField] private float  dodging_forward = 5f; //how much to move forward
    [SerializeField] private float  dodging_timer = 0.5f; //how much to move forward
    

    private GameObject selectedGun = null;    
    public GameObject SelectedGun
    {
        get => selectedGun;
        set { selectedGun = value;
            if (selectedGun != null){
                Debug.Log("=== SelectedGun:" + selectedGun.name);
            }
        }
    }

    // [Header("LockTraget")]
    // [SerializeField] private float A
    // [SerializeField] private float slidSpeed = 1f;
    private bool canDodging = true;
    private bool canSwitchWeapon = true;
    public bool CanSwitchWeapon
    {
        get => canSwitchWeapon;
        set { canSwitchWeapon = value; }
    }

    private State _state = State.Normal;
    // private State state;
    private State state
    {
        get => _state;
        set {  

            if (_state == value) return;
            _state = value;
            ChangeState(_state);
        }
    }
    
    public enum State{
        Normal,
        DodgeRollSliding,
    }
    // [SerializeField] protected GameObject playerBody;
    
    // public Button ShootBtn;
    // public Button[] skillBtn;

    private void Awake() {
        state = State.Normal;
    }
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
        Debug.Log("=== current_Weapon: "+ current_Weapon);
        Transform weaponPos , SecweaponPos;
        
        weaponPos = holdGunPos.transform ;
        SecweaponPos = SecGunPositon.transform ;

        ResetGunPosition(weaponList[current_Weapon] , weaponPos );
        ResetGunPosition(weaponList[lastWeapon] , SecweaponPos );
        
        GetWeapon_onHold(); // switch Base Gun Sprite in base character

    }
    

    public void dodge_click (Button btn ){
        StartCoroutine( dodge_func(btn) );
    }
    private IEnumerator dodge_func ( Button btn ){
        Debug.Log("=== canDodging: " + canDodging);
        if (canDodging)
        {  
            canDodging = false;
            
            StartCoroutine(dodgeing_move() );
            state = State.DodgeRollSliding;
            
            yield return Button_Loading(btn ,dodge_timer );
            canDodging = true;
            // state = State.Normal;
        }
    }

    private IEnumerator dodgeing_move(){

        // this.gameObject.transform.DOMove(new Vector3(2,2,2), 1);
        this.gameObject.transform.DOMove(this.gameObject.transform.position+ this.gameObject.transform.forward * dodging_forward, dodging_timer);

        yield return new WaitForSeconds(dodging_timer);
        state = State.Normal;
// float movementSpeed = 10f;
// this.gameObject.transform.position += transform.forward * Time.deltaTime * movementSpeed;

        // float slidSpeed = 15000f;
        // this.gameObject.transform.localPosition +=  new Vector3(0,0,1)  * slidSpeed *Time.deltaTime;
        // this.gameObject.transform.localPosition = new Vector3 (0,0, 15)  *slidSpeed *Time.deltaTime;

    }

    private bool CanMove(){

        DOTween.Kill(this.gameObject);
        return false;

    }
    private bool TryMove(){
        return false;
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
    
    

    /// Switch Weapon 
    public void SwitchWeapon_click (Button btn , Button interacteBtn){
        // Debug.Log(" SwitchWeapon_click HoldWeaponCount: "+HoldWeaponCount + " || current: " +currentWeapon);
        if (HoldWeaponCount > 1) // MaxGun already Get two Gun
        {    
            StartCoroutine( SwitchWeapon_func(btn , interacteBtn) );
        }
    }
    private IEnumerator SwitchWeapon_func ( Button btn , Button interacteBtn){
        if (weaponList.Count == 0){
            yield break;
        }

        if (CanSwitchWeapon)
        {  
            CanSwitchWeapon = false;
            interacteBtn.interactable = false; // block sametime press Btn
            // canDodging = true;
            yield return Button_Loading(btn ,SwitchWeapon_timer );
            CanSwitchWeapon = true;
            interacteBtn.interactable = true; // block sametime press Btn

            switchingWeapon_func();
        }
    }


    private void LockTraget_func(){
        
    }


    public override void WeaponGet(GameObject obj)
    {
        base.WeaponGet(obj);
    }
    
    // Update is called once per frame
    void Update()
    {
        // PressShoot();

        if (Input.GetKeyDown("space"))      // Test Function
        {
            // switchingWeapon_func(); 

            // state = State.DodgeRollSliding;
            // StartCoroutine(dodgeing_move() );
            
        }

    }

    public void ChangeState(State changeState ){
        switch(state){
            case State.Normal:
                if (joystickPlayerScript.isEnabled == false){
                    joystickPlayerScript.isEnabled = true;
                }
                break;
            
            case State.DodgeRollSliding:
                joystickPlayerScript.isEnabled = false;
                break;
        }
    }

    protected override void CheckHp(){
        if (Current_health == 0)
        {
            ApplyPlayerDie?.Invoke();
            Debug.Log(" Player is die need to destory !!!");
            DestroyOjbect(DestroyOjbectTimer);
        }
    }

    public void WeaponGet_Select(GameObject obj ){
        GameObject weapon = obj;
        BaseGun baseGun = weapon.GetComponent<BaseGun>();
        baseGun.PopupGunInfo();
        SelectedGun = obj;

        ApplyBtnGetGun?.Invoke();
    }

    public void WeaponTriggerExit(){
        SelectedGun = null;
        // baseGun.PopupGunInfo();
        ApplyBtnRemoveGun?.Invoke();
    }


    public void GunSkill_func(){
        
    }
}
