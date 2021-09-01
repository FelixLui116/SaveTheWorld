using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SkillElement : MonoBehaviour{
    public enum WeaponSkillTpye { SpeedUp, DamageUp , ShootThrough }   
    public WeaponSkillTpye weaponSkillTpye;
    [SerializeField] private float cooldownTime = 5;
    [SerializeField] private float holdTime = 2.0f;
    public float shotingSpeed = 0.0f;
    public float damageUp = 0.0f;
    private bool canGunSkill = true;    
    public bool CanGunSkill
    {
        get => canGunSkill;
        set { canGunSkill = value; }
    }

    public float HoldTime
    {
        get => holdTime;
        // set { holdTime = value; }
    }

    private GunDefault gunDefault;

    private BaseGun baseGun;
    // public float trytry = 0.0f;
    private void Awake() {
        baseGun = this.gameObject.GetComponent<BaseGun>();
        baseGun.skill_text = weaponSkillTpye.ToString(); 
        gunDefault = new GunDefault();
        SkillReset(false);

    }
    public void PowerUp(){

    }
    public void FireSpeedUp(float num = 0.0f){

    }

    public void GunSkill_click (Button btn ){
        StartCoroutine( GunSkill_func(btn) );
    }
    private IEnumerator GunSkill_func ( Button btn ){
        
        if (CanGunSkill)
        {  
            CanGunSkill = false;
            baseGun.gunSkill_on = true;
            StartCoroutine( SkillHit() );
            StartCoroutine( BtnIsOn(btn , holdTime) );
            yield return Button_Loading(btn , cooldownTime);
            CanGunSkill = true;
            // StartCoroutine( SkillReset() );
            // SkillReset()
        }
    }

    private IEnumerator SkillHit(){
        // Debug.Log(" skillElement.skillTpye: "+ weaponSkillTpye); // SpeedUp, DamageUp , ShootThrough
        switch (weaponSkillTpye)
        {
            case WeaponSkillTpye.SpeedUp:
                baseGun.FireRate += shotingSpeed;
            // Debug.Log("== A ==");
                break;
            case WeaponSkillTpye.DamageUp:
                baseGun.WeaponDamage += damageUp;
                // Debug.Log("== B ==");
                break;
            case WeaponSkillTpye.ShootThrough:
            // Debug.Log("== C ==");
                baseGun.canPassThrough = true;
                break;
            default:
                break;
        }
        
        yield return new WaitForSeconds(holdTime);
        baseGun.gunSkill_on = false;
        SkillReset();
    }

    private IEnumerator Button_Loading(Button btn , float countTimer ){
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
    private void SkillReset(bool isReset = true){
        // yield return new WaitForFixedUpdate();
        Debug.Log("SkillReset: " + isReset);
        if (isReset)
        {
            baseGun.WeaponDamage    = gunDefault.WeaponDamage ;
            baseGun.FireRate        = gunDefault.FireRate  ;
            baseGun.BulletSpeed     = gunDefault.BulletSpeed  ;
            baseGun.BulletRange     = gunDefault.BulletRange  ;
            baseGun.BulletDestoryTime = gunDefault.BulletDestoryTime;
            baseGun.canPassThrough  = gunDefault.canPassThrough;
        }else{      // set default value
            gunDefault.WeaponDamage = baseGun.WeaponDamage;
            gunDefault.FireRate     = baseGun.FireRate;
            gunDefault.BulletSpeed  = baseGun.BulletSpeed;
            gunDefault.BulletRange  = baseGun.BulletRange;
            gunDefault.BulletDestoryTime=baseGun.BulletDestoryTime;
            gunDefault.canPassThrough = baseGun.canPassThrough;
        }
    }

    private IEnumerator BtnIsOn(Button btn , float countTimer){
        // Button isOnBtn = btn.gameObject.GetChild(2).GetComponent<Button>(); // GunSkill 3 isOn object
        var LoadingBar = btn.transform.GetChild(2).GetComponent<Image>();
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
}

public class GunDefault {
    public float WeaponDamage, FireRate , 
    BulletSpeed ,BulletRange,
    BulletDestoryTime;
    public bool canPassThrough =false;
}
// #if UNITY_EDITOR
//     [CustomEditor(typeof(SkillElement))]
//     public class GunSkillEditor : Editor {

//         public override void OnInspectorGUI() {
//             base.OnInspectorGUI();
//             // SkillElement skillElement = (SkillElement)target;
//             EditorGUILayout.LabelField("Element");
//             EditorGUILayout.BeginHorizontal();

//             // skillElement.ShotingSpeed = EditorGUILayout.FloatField(skillElement.ShotingSpeed );
//             // SkillElement.FindProperty("weaponEnd");
//         }
//         // Start is called before the first frame update
//         // void Start()
//         // {
            
//         // }

//         // // Update is called once per frame
//         // void Update()
//         // {
            
//         // }  
//     }
// #endif

