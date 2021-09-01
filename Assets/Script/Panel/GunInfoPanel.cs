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
    [SerializeField] private Transform AbiliyParent;
    [SerializeField] private GameObject elementClone;
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

    public void updateInfoText(string typeName_ = "" , string damage_ = "" , string skill_text = ""){
        typeName.text = typeName_;
        damage.text = damage_;

            // Instantiate( elementClone , AbiliyParent);
        // if (skill_text != ""){
            
            GameObject elementClone_Obj = Instantiate( elementClone , AbiliyParent );
            elementClone_Obj.SetActive(true);
            Text element_txt = elementClone_Obj.GetComponent<Text>();
            element_txt.text = skill_text;
        // }
    }
    public void DestroyTimer(){
        Destroy( gameObject , DestroyTime);
    }

    public void elementClone_text(){
        
    }
}
