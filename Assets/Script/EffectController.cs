using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{ 
    public static EffectController Instance { get; private set; }
    [SerializeField] private ParticleSystem coinEffect;
    [SerializeField] private ParticleSystem MedKitEffect;
    [SerializeField] private ParticleSystem GunSkill_SpeedUpEffect;
    [SerializeField] private ParticleSystem GunSkill_DamageUpEffect;
    [SerializeField] private ParticleSystem GunSkill_ShootThroughEffect;

    private void Awake() {
        if (Instance == null){
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private ParticleSystem GetEffect(string s = "" ){
    //     ParticleSystem particleSystem = null;

    //     switch (s)
    //     {
    //         case "Coin":
    //             particleSystem = coinEffect;
    //             break;
    //         case "MedKit":
    //             particleSystem = MedKitEffect;
    //             break;
    //         case "DamageUp":
    //             particleSystem = GunSkill_DamageUpEffect;
    //             break;
    //         case "SpeedUp":
    //             particleSystem = GunSkill_SpeedUpEffect;
    //             break;
    //         case "ShootThrough":
    //             particleSystem = GunSkill_ShootThroughEffect;
    //             break;
    //         default:
    //             break;
    //     }
    
    //     return particleSystem;
    // }

    public void CreateEffect(string getEffectname , Transform parnet , float timer = 1.0f ){

        // ParticleSystem PS = GetEffect(getEffectname);
        // if (PS != null)
        // {
        //     GameObject PS_clone = Instantiate( PS.gameObject, parnet);
        //     var _ps = PS_clone.GetComponent<ParticleSystem>();
        //     _ps.Stop();
        //     var main = _ps.main;
        //     main.duration = timer;
        //     main.startColor = Color.blue;
        //     _ps.Play();

        //     //  StartCoroutine( CloseEffect(PS , timer) );
        // }

        Color color = new Color();
        ParticleSystem PS = new ParticleSystem();
        GetEffect(getEffectname , ref PS ,ref color);
        if (PS != null)
        {
            GameObject PS_clone = Instantiate( PS.gameObject, parnet);
            var _ps = PS_clone.GetComponent<ParticleSystem>();
            _ps.Stop();
            var main = _ps.main;
            main.duration = timer;
            main.startColor = color;
            _ps.Play();

            //  StartCoroutine( CloseEffect(PS , timer) );
        }
    }

    private void GetEffect(string s  , ref ParticleSystem particleSystem, ref Color _color ){
        
        switch (s)
        {
            case "Coin":
                particleSystem = coinEffect;
                _color = Color.yellow;
                break;
            case "MedKit":
                particleSystem = MedKitEffect;
                _color = Color.red; 
                break;
            case "DamageUp":
                particleSystem = GunSkill_DamageUpEffect;
                _color = Color.red; 
                break;
            case "SpeedUp":
                particleSystem = GunSkill_SpeedUpEffect;
                _color = Color.blue;
                break;
            case "ShootThrough":
                particleSystem = GunSkill_ShootThroughEffect;
                _color = Color.yellow;
                break;
            default:
                break;
        }
                // _color = Color.yellow;
    }
    // private IEnumerator CloseEffect(ParticleSystem PS , float timer){
         
    //     yield return new WaitForSeconds(timer);
    //     PS.Stop();
        
    // }
}
