using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSparks : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] private float timer = 1f;
    void Start()
    {
         StartCoroutine(CreateHitParaticle(timer) );
    }
    private IEnumerator  CreateHitParaticle(float timer = 1f){
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
