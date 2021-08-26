using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunInfoPanel : BasePanel
{
    // Start is called before the first frame update
    [SerializeField] private Text typeName;
    [SerializeField] private Text damage;
    //   [SerializeField] private 
    void Start()
    {
        // Vector3 Offset = new Vector3(0,2,0);
        // transform.localPosition += Offset; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyTimer(float timer = 0.0f){
        Destroy( gameObject );
    }
}
