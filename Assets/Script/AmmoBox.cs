using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : BaseItem
{
    // Start is called before the first frame update
    public enum AmmoTpye { Blue, green, yellow, red }
    public AmmoTpye ammoTpye;
    [Range(0, 1000)] public int AmmoNum = 0;

    void Start()
    { 
        int i = ammoTpye == AmmoTpye.Blue   ? 0 :
                ammoTpye == AmmoTpye.green  ? 1 :
                ammoTpye == AmmoTpye.yellow ? 2 :
                ammoTpye == AmmoTpye.red    ? 3 : 0;

        // audio_Collision.clip = ResourcesAudio.Instance.Ammo_Audio[i];
    }
    private void OnTriggerEnter(Collider other) {
        // Debug.Log(" in AmmoBox Collistion " + other.gameObject.name);
        if(other.gameObject.tag == "Player")
        {
            DestroyItem();
            AudioPlayer(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
