using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : BaseItem
{
    // Start is called before the first frame update

    [Range(0, 1000)] public int HealingNum = 0;
    void Start()
    {
        audio_Collision.clip = ResourcesAudio.Instance.medkit;
    }
    // protected override void OnCollisionEnter(Collision other){
    //     Debug.Log(" in Med Kit " + other.gameObject.name);
    //     // Add health to other(BaseCharater) -> levelController

    //     base.OnCollisionEnter(other);
    //     // add player health
    //     // baseCharacter.current_health += HealingNum;
    // }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(" in Coin OnTriggerEnter " + other.gameObject.name);
        AudioPlayer(); 
        DestroyItem();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
