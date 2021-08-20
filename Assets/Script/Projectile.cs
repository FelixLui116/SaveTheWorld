using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;  
using Random = UnityEngine.Random;
public class Projectile : MonoBehaviour
{
    public Rigidbody Bullet_rb;
    // public float destroyTime;
    public float bulletDamage;
    public bool canPassThrough_bullet = false;

    public TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // if (hitEffect != null)
        // {
        //     if (other.gameObject.GetComponent<Enemy>() != null)
        //         hitEffect.transform.GetChild(1).GetComponent<ParticleSystemRenderer>().sharedMaterial.color = Color.red;
        //     else
        //         hitEffect.transform.GetChild(1).GetComponent<ParticleSystemRenderer>().sharedMaterial.color = new Color(1, 0.99f, 0.8f);
        //     poolSystem.Spawn(hitEffect, other.GetContact(0).point, Quaternion.LookRotation(other.GetContact(0).normal));
        //     if (areaDamage)
        //         StaticHelperClass.DamageArea(other.GetContact(0).point, areaRadius, weaponDamage);
        // }
        // poolSystem.poolDictionary[bulletName].Enqueue(gameObject);
        // gameObject.SetActive(false);

        // /////////////

        // if (other.gameObject.GetComponent<Health>() != null){
        //     // enemy -HP    // show some effect
        //     if (other.gameObject.tag == "Enemy" != null){
        //         Debug.Log(" Hit tag enemy!!! ");
        //     }
            
        // }
        // else if(other.collider.name == "wall"){
        //     Debug.Log(" is enter the wall!!!");
        // }
    }

    public async void Fire(float bulletSpeed ,float  bulletRange, float bulletDestory , Vector3 pos , Quaternion rotation , float damage , Color trailColor , bool passThrough){
        
        bulletDamage = damage;
        canPassThrough_bullet = passThrough;
        // reset pos to Gun FirePoint Pos
        transform.position = pos;
        transform.rotation = rotation;

        // Debug.Log("=: " + pos + rotation + " ~~ "+transform.position  +transform.rotation);

        if (trail!= null ){
            trail.enabled = true;
            SetTrailColor(trailColor);
        }
        
        
        float range =0.0f;
        if (bulletRange != 0){
            range = Random.Range( -(bulletRange), bulletRange);
            // Debug.Log("-----Range : " + Math.Round(range , 2) );
            range = (float)Math.Round(range , 2);   // to 0.00 
            // this.transform.Rotate(0,  range , 0);   // addRange <-->  
        }

        Quaternion _rotation = Quaternion.Euler(0, (transform.localRotation.eulerAngles.y + range), 0);// addRange <-->  (0, range, 0)
        Vector3 direction = _rotation * Vector3.forward;
        // Debug.Log("direction: " + direction);
        Bullet_rb.AddForce(direction * bulletSpeed * 100);  // 100 may not need 40* 100 is OK
        
        StartCoroutine(DestroyTimer(bulletDestory) );
    }

    public IEnumerator DestroyTimer(float seconds)
    {
        Debug.Log("before bulletDestory: " + seconds);
        yield return new WaitForSeconds(seconds);
        Debug.Log("after bulletDestory: " );
        // ResetVelocity();
        // poolSystem.poolDictionary[bulletName].Enqueue(gameObject);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void DestroyObj(){
        Destroy(gameObject);
    }

    
    private void SetTrailColor( Color trailColor){

        // Color i = trailColor == TrailColor.blue   ? Color.blue :
        //         trailColor == TrailColor.green  ? Color.green :
        //         trailColor == TrailColor.yellow ? Color.yellow :
        //         trailColor == TrailColor.red    ? Color.red : Color.blue;

        trail.endColor = Color.white;
        trail.startColor = trailColor; 
    }
}
