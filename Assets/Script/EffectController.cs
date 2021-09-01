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

    private ParticleSystem GetEffect(string s = "" ){
        ParticleSystem particleSystem = null;

        switch (s)
        {
            case "Coin":
                particleSystem = coinEffect;
                break;
            case "MedKit":
                particleSystem = MedKitEffect;
                break;
            case "DamageUp":
                particleSystem = GunSkill_DamageUpEffect;
                break;
            case "SpeedUp":
                particleSystem = GunSkill_SpeedUpEffect;
                break;
            case "ShootThrough":
                particleSystem = GunSkill_ShootThroughEffect;
                break;
            default:
                break;
        }

        return particleSystem;
    }

    public void CreateEffect(string getEffectname , Transform parnet , float timer = 1.0f ){
        // GameObject clone = CloneEffect();
        ParticleSystem PS = GetEffect(getEffectname);
        if (PS != null)
        {
            GameObject PS_clone = Instantiate( PS.gameObject, parnet);
            var main = PS_clone.GetComponent<ParticleSystem>().main;
            main.duration = timer;
            //  StartCoroutine( CloseEffect(PS , timer) );
        }
    }
    // private IEnumerator CloseEffect(ParticleSystem PS , float timer){
         
    //     yield return new WaitForSeconds(timer);
    //     PS.Stop();
        
    // }
}
