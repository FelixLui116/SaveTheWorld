using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;  
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Testonly : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public int bulletSpeed = 100;

    public Camera canvas;
    public Transform TextImage;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Space key was pressed.");
            // Test();
            // Test2();
            // CloneText();

        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z key was pressed.");

            // rb.velocity = Vector3.zero;
        }
    }

    public void CloneText(){
        FloatingText popupText = null;
        // canvas = GameObject.Find("Canvas");
        if (!popupText){
            popupText = Resources.Load<FloatingText>("Prefabs/FloatingText");
        }
    
        // FloatingText instance = Instantiate(popupText);
        Vector2 screenPosition = canvas.WorldToScreenPoint(transform.position);
        Debug.Log( (screenPosition.x  )+ " !! "+ screenPosition.y);
        TextImage.position = screenPosition;

        // instance.transform.SetParent(canvas.transform, false);
        // instance.transform.position = screenPosition;
        // instance.SetText("123");
    
    }

    public void Test(){
        // rb.AddForce(transform.forward * bulletSpeed);   // working  move forward only

        // //   clone "Instantiate"
        // Quaternion myRotation = Quaternion.identity;
        // myRotation.eulerAngles = new Vector3(150, 35, 45);
        // var projectile = Instantiate (rb, Vector3.zero , myRotation );
        // //Shoot the Bullet in the forward direction of the player
        // projectile.AddForce(transform.forward * bulletSpeed);   // working 
        // // 


        //  is working in moving LocationRotation
        // Quaternion.Euler(0, 90, 0); rotation  // transform.rotation.x , transform.rotation.y ,  transform.rotation.z
        Quaternion rotation = Quaternion.Euler( 0,transform.localRotation.eulerAngles.y ,0 );
        Vector3 direction = rotation * Vector3.forward;
        Debug.Log("/*" + direction + transform.localRotation.eulerAngles.y );
        rb.AddForce(direction * bulletSpeed);   // working 
        //


        // using  Random  Rotation range 
        // float range =0.0f;
        // float bulletRange = 45.0f;
        //     range = Random.Range( -(bulletRange), bulletRange);
        //     // Debug.Log("-----Range : " + Math.Round(range , 2) );
        //     range = (float)Math.Round(range , 2);   // to 0.00 
        //     // this.transform.Rotate(0,  range , 0);   // addRange <-->  range = Random.Range( -(bulletRange), bulletRange);
        //     Debug.Log("-----Range : " + Math.Round(range , 2) );
        // range = (float)Math.Round(range , 2);   // to 0.00 

        // Quaternion rotation = Quaternion.Euler( 0,(transform.localRotation.eulerAngles.y + range) ,0 );
        // Vector3 direction = rotation * Vector3.forward;
        // Debug.Log("/*" + direction + (transform.localRotation.eulerAngles.y + range) );
        // rb.AddForce(direction * bulletSpeed);   // working 
        // /// 
    }

    public void Test2(){     //   Random func
         float range =0.0f;
         float bulletRange = 5.0f;
            range = Random.Range( -(bulletRange), bulletRange);
            // Debug.Log("-----Range : " + Math.Round(range , 2) );
            range = (float)Math.Round(range , 2);   // to 0.00 
            // this.transform.Rotate(0,  range , 0);   // addRange <-->  range = Random.Range( -(bulletRange), bulletRange);
            Debug.Log("-----Range : " + Math.Round(range , 2) );
        range = (float)Math.Round(range , 2);   // to 0.00 
    }    


    public Text AmmoText;
    public void Ammo_text_update(int CurrentAmmo ,int TotalAmmo ,int Ammo){
    //     // something like this dispaly
    //     //  0/28
    //     //  200
            AmmoText.text = BulletText( CurrentAmmo, TotalAmmo , Ammo );
    }
    private string BulletText(int CurrentAmmo ,int TotalAmmo ,int Ammo) // CurrentAmmo/ TotalAmmo  (new line) Ammo
    {
        if (Ammo!= null){
            
        }
        return  CurrentAmmo +"/"+ TotalAmmo + "\n" + Ammo;
    }
}

//  draft  draft draft draft draft draft draft draft draft

//  maybe need Occlusion culling ( render only camera view )
//

// /*
public class TestClass{     
    // base gun Class

    // public GameObject gun_Flash;     // gun flash light
    // gun_Flash.SetActive(true);
    // gun_Flash.SetActive(false);


    // public AudioSource audio_Source;
    //  audio_Source.clip = ResourcesAudio.Instance.Gun_1[(int)GunAudio.FIRE];
    // AudioPlayer();  // need Resoucse Sound to get clip
    //  audio_Source.clip = ResourcesAudio.Instance.Gun_1[(int)GunAudio.RELOAD];
    // AudioPlayer();  // need Resoucse Sound to get clip

    // public void AudioPlayer(){ 

    //     if (audio_Source != null)
    //     {
    //         audio_Source.Play();
    //     }
    // }

    // /// end base gun class
    // //////////////////////////////////

    // ///   Bullet GameObject 
    // add Trail Renderer

    // if (other.tag == "Wall")
    // {
    //     Destory(this.gameObject);
    // }

    // /// end
    // //////////////////////////////////


    //class  levelController 
    // public Text health_text;
    // public Text[] Ammo_text;
    // public Text Debug_Text;

    // // public image Gun_UIimage = null;  // baseCharacter.baseGun. ( WeaponImg , WeaponImg_Disable)

 
    // public Text AmmoText;
    
    // // like this Ammo_text_update(1,28, 1000); 
    // public void Ammo_text_update(int CurrentAmmo ,int TotalAmmo ,int Ammo){
    // //     // something like this dispaly
    // //     //  0/28
    // //     //  200
    //         AmmoText.text = BulletText( CurrentAmmo, TotalAmmo , Ammo );
    // }
    // private string BulletText(int CurrentAmmo ,int TotalAmmo ,int Ammo) // CurrentAmmo/ TotalAmmo  (new line) Ammo
    // {
    //     if (Ammo!= null){
            
    //     }
    //     return  CurrentAmmo +"/"+ TotalAmmo + "\n" + Ammo;
    // }

    // private void PlayerHealth_text_update ( int health_ )
    // {
    //     health_text.text = health_;
    // }
    // /// end
    // //////////////////////////////////

    

}
// */ 
