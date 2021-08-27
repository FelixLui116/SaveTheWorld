using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunInfoPanel : BasePanel
{
    // Start is called before the first frame update
    [SerializeField] private Text typeName;
    [SerializeField] private Text damage;
    private float DestroyTime = 0.2f; // delay
    void Start()
    {
        // Vector3 Offset = new Vector3(0,2,0);
        // transform.localPosition += Offset; 

        // DestroyTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateInfoText(string typeName_ = "" , string damage_ = ""){
        typeName.text = typeName_;
        damage.text = damage_;
    }
    public void DestroyTimer(){
        Destroy( gameObject , DestroyTime);
    }
}
