using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    // Start is called before the first frame update

    public float DestroyTime = 0.1f;

    public AudioSource audio_Collision;
    // public BaseCharacter baseCharacter;

    private bool isCollision = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // protected virtual void OnCollisionEnter(Collision other) {
        // if(isCollision){ return; } // was touched / Got it alreadly
        // Debug.Log("===" + other.gameObject.name);
        // if (other.gameObject.tag == "Player"){
        //     Debug.Log(" Get Base Item !!!");
        //     isCollision = true;
        //     // get player Controller -> heal HP += 
        //     // baseCharacter = other.gameObject.GetComponent<BaseCharacter>();

        //     AudioPlayer();  // need Resoucse Sound to get clip
        //     DestroyTimer(DestroyTime);
        // }
    // }

    IEnumerator DestroyTimer(float seconds)
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    public void AudioPlayer(){ 
        // AudioSource audio = gameObject.GetComponent<AudioSource>();
        // audio.clip = _clip;
        if (audio_Collision != null)
        {
            Debug.Log("is Audio Player");
            audio_Collision.PlayOneShot(audio_Collision.clip ,1);
        }
    }
}
